using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ContractManagementSystem_CMS_.Services
{
    public class AIService : IDisposable
    {
        private readonly HttpClient _httpClient;
        private const string Model = "qwen2.5:7b";
        private const string OllamaUrl = "http://localhost:11434";

        public class AIAnalysisResult
        {
            public string Summary { get; set; }
            public double RiskScore { get; set; }
            public string RiskLevel { get; set; }
            public List<AIModuleDetail> Details { get; set; }
            public List<string> Recommendations { get; set; }
            public string RawResponse { get; set; }
        }

        public class AIModuleDetail
        {
            public string Title { get; set; }
            public string Content { get; set; }
            public string Risk { get; set; }
            public string Explanation { get; set; }
        }

        public AIService()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(OllamaUrl),
                Timeout = TimeSpan.FromSeconds(120)
            };
        }

        public async Task<bool> CheckConnectionAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync("/api/tags");
                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }

        public async Task<AIAnalysisResult> AnalyzeContractAsync(string contractText, string contractType)
        {
            string systemPrompt = @"Sen bir Türk hukuku sözleşme analiz uzmanısın. Verilen sözleşmeyi analiz et ve şu formatta JSON döndür:

{
  ""summary"": ""Sözleşmenin kısa özeti"",
  ""riskScore"": 0-100 arası bir skor (100=risksiz, 0=çok riskli),
  ""riskLevel"": ""Düşük Risk"" | ""Orta Risk"" | ""Yüksek Risk"",
  ""details"": [
    {
      ""title"": ""Madde başlığı veya konu"",
      ""content"": ""Madde ile ilgili tespit"",
      ""risk"": ""Düşük"" | ""Orta"" | ""Yüksek"" | ""Kritik"",
      ""explanation"": ""Bu maddenin neden riskli olduğu veya olmadığı""
    }
  ],
  ""recommendations"": [
    ""Madde 1: ..."",
    ""Madde 2: ...""
  ]
}

Sadece JSON döndür, başka bir şey yazma. Türkçe yanıt ver.";

            string userMessage = $"Sözleşme Türü: {contractType}\n\nSözleşme İçeriği:\n{contractText}";
            string response = await SendChatMessageAsync(systemPrompt, userMessage);

            var result = new AIAnalysisResult { RawResponse = response };

            try
            {
                var cleaned = CleanJsonResponse(response);
                using var doc = JsonDocument.Parse(cleaned);
                var root = doc.RootElement;

                if (root.TryGetProperty("summary", out var summary))
                    result.Summary = summary.GetString();
                if (root.TryGetProperty("riskScore", out var riskScore))
                    result.RiskScore = riskScore.GetDouble();
                if (root.TryGetProperty("riskLevel", out var riskLevel))
                    result.RiskLevel = riskLevel.GetString();

                result.Details = new List<AIModuleDetail>();
                if (root.TryGetProperty("details", out var details))
                {
                    foreach (var detail in details.EnumerateArray())
                    {
                        var moduleDetail = new AIModuleDetail();
                        if (detail.TryGetProperty("title", out var title)) moduleDetail.Title = title.GetString();
                        if (detail.TryGetProperty("content", out var content)) moduleDetail.Content = content.GetString();
                        if (detail.TryGetProperty("risk", out var risk)) moduleDetail.Risk = risk.GetString();
                        if (detail.TryGetProperty("explanation", out var explanation)) moduleDetail.Explanation = explanation.GetString();
                        result.Details.Add(moduleDetail);
                    }
                }

                result.Recommendations = new List<string>();
                if (root.TryGetProperty("recommendations", out var recommendations))
                {
                    foreach (var rec in recommendations.EnumerateArray())
                        result.Recommendations.Add(rec.GetString());
                }
            }
            catch (Exception ex)
            {
                Trace.WriteLine($"[AIService] JSON parse hatası: {ex.Message}");
                result.Summary = "AI yanıtı parse edilemedi. Ham yanıt aşağıda.";
                result.RiskLevel = "Bilinmiyor";
                result.Details = new List<AIModuleDetail>();
                result.Recommendations = new List<string>();
            }

            return result;
        }

        public async Task<string> SummarizeContractAsync(string contractText)
        {
            string systemPrompt = @"Verilen sözleşmeyi Türkçe olarak özetle. Özet şu bilgileri içermeli:
1. Sözleşme türü
2. Taraflar
3. Temel hükümler
4. Süre ve koşullar
5. Önemli maddeler

Kısa ve anlaşılır bir özet yaz.";
            return await SendChatMessageAsync(systemPrompt, contractText);
        }

        public async Task<string> SuggestFixAsync(string problematicClause, string context)
        {
            string systemPrompt = @"Verilen sorunlu sözleşme maddesini analiz et ve daha iyi bir versiyonunu öner.
Türk hukuku standartlarına uygun, dengeli ve adil bir dil kullan.
Orijinal maddeyi ve önerilen düzeltmeyi sun.";
            string userMessage = $"Sözleşme Bağlamı: {context}\n\nSorunlu Madde:\n{problematicClause}";
            return await SendChatMessageAsync(systemPrompt, userMessage);
        }

        private async Task<string> SendChatMessageAsync(string systemPrompt, string userMessage)
        {
            var request = new
            {
                model = Model,
                messages = new object[]
                {
                    new { role = "system", content = systemPrompt },
                    new { role = "user", content = userMessage }
                },
                stream = false
            };

            string json = JsonSerializer.Serialize(request);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("/api/chat", content);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();

            using var doc = JsonDocument.Parse(responseBody);
            var root = doc.RootElement;
            if (root.TryGetProperty("message", out var message) &&
                message.TryGetProperty("content", out var msgContent))
                return msgContent.GetString();

            return responseBody;
        }

        private string CleanJsonResponse(string response)
        {
            string cleaned = response.Trim();
            int jsonStart = cleaned.IndexOf('{');
            int jsonEnd = cleaned.LastIndexOf('}');
            if (jsonStart >= 0 && jsonEnd > jsonStart)
                cleaned = cleaned.Substring(jsonStart, jsonEnd - jsonStart + 1);
            return cleaned;
        }

        public void Dispose()
        {
            _httpClient?.Dispose();
        }
    }
}
