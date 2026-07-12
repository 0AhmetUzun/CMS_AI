using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using ContractManagementSystem_CMS_.Models;

namespace ContractManagementSystem_CMS_.Services
{
    public class AIService : IDisposable
    {
        private readonly HttpClient _httpClient;
        private const string Model = "qwen2.5:7b";
        private const string OllamaUrl = "http://localhost:11434";

        public class AIAnalysisResult
        {
            public string Summary { get; set; } = null!;
            public double RiskScore { get; set; }
            public string RiskLevel { get; set; } = null!;
            public List<AIModuleDetail> Details { get; set; } = null!;
            public List<string> Recommendations { get; set; } = null!;
            public string RawResponse { get; set; } = null!;
        }

        public class AIModuleDetail
        {
            public string Title { get; set; } = null!;
            public string Content { get; set; } = null!;
            public string Risk { get; set; } = null!;
            public string Explanation { get; set; } = null!;
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

ÖNEMLİ: ""recommendations"" dizisini ASLA BOŞ BIRAKMA, EN AZ 2-3 MADDE EKLE. Eğer risk tespit edildiyse her biri için düzeltme önerisi yaz.

ÖNEMLİ - Aşağıdaki riskleri MUTLAKA tespit et ve details dizisine ekle (her biri için risk seviyesini Düşük/Orta/Yüksek/Kritik olarak belirt):
- Belirsiz süre/tarih: net başlangıç veya bitiş tarihi yoksa.
- Aşırı cezai şart veya orantısız gecikme cezası: yüksek yüzde/yürürlükteki sınırların üzerinde tutar.
- Çelişki: fesih bildirim süresi ile yenileme bildirim süresi birbiriyle uyumsuzsa; ya da ödeme vadesi ile teslim koşulu çelişiyorsa.
- Otomatik yenileme varsa ve iptal/çıkış bildirim koşulu bulunmuyorsa (zor iptalli otomatik yenileme).
- Ödeme koşulunun muğlak olması: ""eylem gerçekleştiğinde"", ""uygun gördüğü şekilde"", ""makul süre"" gibi ifadeler.
- Sınırsız sorumluluk, kontrol dışı tazminat (indemnification), ""for convenience"" geniş fesih hakkı.
- Kişisel kefalet, aşırı/uzun gizlilik veya aşırı rekabet yasağı.
- Türkiye özel: haksız şart (TKHK m.5), cayma hakkı eksikliği, ayıp sorumluluğu (2 yıl), kira artışının TÜFE ile sınırlı olmaması.
Her details öğesinde ""content"" alanına ilgili maddenin SÖZÜNÜ DOĞRUDAN alıntıla (kaynak gösterimi).

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
                    result.Summary = summary.GetString() ?? "";
                if (root.TryGetProperty("riskScore", out var riskScore))
                    result.RiskScore = riskScore.GetDouble();
                if (root.TryGetProperty("riskLevel", out var riskLevel))
                    result.RiskLevel = riskLevel.GetString() ?? "";

                result.Details = new List<AIModuleDetail>();
                if (root.TryGetProperty("details", out var details))
                {
                    foreach (var detail in details.EnumerateArray())
                    {
                        var moduleDetail = new AIModuleDetail();
                        if (detail.TryGetProperty("title", out var title)) moduleDetail.Title = title.GetString() ?? "";
                        if (detail.TryGetProperty("content", out var content)) moduleDetail.Content = content.GetString() ?? "";
                        if (detail.TryGetProperty("risk", out var risk)) moduleDetail.Risk = risk.GetString() ?? "";
                        if (detail.TryGetProperty("explanation", out var explanation)) moduleDetail.Explanation = explanation.GetString() ?? "";
                        result.Details.Add(moduleDetail);
                    }
                }

                result.Recommendations = new List<string>();
                if (root.TryGetProperty("recommendations", out var recommendations))
                {
                    foreach (var rec in recommendations.EnumerateArray())
                    {
                        var recText = rec.GetString();
                        if (recText != null) result.Recommendations.Add(recText);
                    }
                }

                if (result.Recommendations.Count == 0 && result.Details.Count > 0)
                {
                    foreach (var detail in result.Details)
                    {
                        if (!string.IsNullOrWhiteSpace(detail.Explanation))
                            result.Recommendations.Add($"{detail.Title}: {detail.Explanation}");
                    }
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

        public async Task<ContractSummaryResult> GetBriefSummaryAsync(string contractText)
        {
            string systemPrompt = @"Sen bir sözleşme analiz uzmanısın. Verilen sözleşmeyi analiz et ve şu formatta JSON döndür:

{
  ""purpose"": ""Sözleşmenin kısa amacı/kapsamı (1-2 cümle)"",
  ""parties"": ""Taraflar ve aralarındaki ilişki"",
  ""duration"": ""Süre ve başlangıç/bitiş tarihi"",
  ""termination"": ""Fesih koşulları ve yenileme durumu"",
  ""payment"": ""Ödeme tutarı, para birimi ve koşulları"",
  ""keyObligations"": [""Madde 1: ..."", ""Madde 2: ..."", ""Madde 3: ...""],
  ""risks"": [""Uyarı 1: ..."", ""Uyarı 2: ...""]
}

Kısa ve öz ol. Maksimum 5 ana başlık. Türkçe yanıt ver. Sadece JSON döndür.

Risklerde şunlara dikkat et: belirsiz süre/tarih, aşırı cezai şart, fesih-yenileme çelişkisi, zor iptalli otomatik yenileme, muğlak ödeme koşulu, haksız şart/cayma hakkı eksikliği (TKHK).";

            string response = await SendChatMessageAsync(systemPrompt, contractText);
            return ParseSummaryResponse(response);
        }

        public async Task<ContractSummaryResult> GetDetailedSummaryAsync(string contractText)
        {
            string systemPrompt = @"Sen bir sözleşme analiz uzmanısın. Verilen sözleşmeyi detaylı olarak analiz et ve şu formatta JSON döndür:

{
  ""purpose"": ""Sözleşmenin amacı ve kapsamı (2-3 cümle, detaylı)"",
  ""parties"": ""Taraflar, unvanları ve aralarındaki hukuki ilişki"",
  ""duration"": ""Sözleşme süresi, başlangıç tarihi, bitiş tarihi, yenileme koşulları"",
  ""termination"": ""Fesih türleri (olağan/olağanüstü), bildirim süresi, cezai şartlar"",
  ""payment"": ""Ödeme tutarı, para birimi, vade, gecikme faizi, teminat"",
  ""keyObligations"": [""Madde 1: Yükümlülük açıklaması"", ""Madde 2: ..."", ""Madde 3: ..."", ""Madde 4: ..."", ""Madde 5: ...""],
  ""risks"": [""Risk/Uyarı 1: Açıklama"", ""Risk/Uyarı 2: ..."", ""Risk/Uyarı 3: ...""]
}

Detaylı ve kapsamlı yaz. Tüm önemli maddeleri dahil et. Türkçe yanıt ver. Sadece JSON döndür.

Risklerde şunlara dikkat et: belirsiz süre/tarih, aşırı cezai şart, fesih-yenileme çelişkisi, zor iptalli otomatik yenileme, muğlak ödeme koşulu, haksız şart/cayma hakkı eksikliği (TKHK).";

            string response = await SendChatMessageAsync(systemPrompt, contractText);
            return ParseSummaryResponse(response);
        }

        private ContractSummaryResult ParseSummaryResponse(string response)
        {
            var result = new ContractSummaryResult { RawResponse = response };

            try
            {
                var cleaned = CleanJsonResponse(response);
                using var doc = JsonDocument.Parse(cleaned);
                var root = doc.RootElement;

                if (root.TryGetProperty("purpose", out var purpose))
                    result.Purpose = purpose.GetString() ?? "";
                if (root.TryGetProperty("parties", out var parties))
                    result.Parties = parties.GetString() ?? "";
                if (root.TryGetProperty("duration", out var duration))
                    result.Duration = duration.GetString() ?? "";
                if (root.TryGetProperty("termination", out var termination))
                    result.Termination = termination.GetString() ?? "";
                if (root.TryGetProperty("payment", out var payment))
                    result.Payment = payment.GetString() ?? "";

                if (root.TryGetProperty("keyObligations", out var obligations))
                {
                    foreach (var item in obligations.EnumerateArray())
                    {
                        var text = item.GetString();
                        if (text != null) result.KeyObligations.Add(text);
                    }
                }

                if (root.TryGetProperty("risks", out var risks))
                {
                    foreach (var item in risks.EnumerateArray())
                    {
                        var text = item.GetString();
                        if (text != null) result.Risks.Add(text);
                    }
                }
            }
            catch (Exception ex)
            {
                Trace.WriteLine($"[AIService] Özet JSON parse hatası: {ex.Message}");
            }

            return result;
        }

        public async Task<string> SuggestFixAsync(string problematicClause, string context)
        {
            string systemPrompt = @"Verilen sorunlu sözleşme maddesini analiz et ve daha iyi bir versiyonunu öner.
Türk hukuku standartlarına uygun, dengeli ve adil bir dil kullan.
Orijinal maddeyi ve önerilen düzeltmeyi sun.";
            string userMessage = $"Sözleşme Bağlamı: {context}\n\nSorunlu Madde:\n{problematicClause}";
            return await SendChatMessageAsync(systemPrompt, userMessage);
        }

        public async Task<string> DraftClauseAsync(string instruction)
        {
            string systemPrompt = @"Sen bir Türk hukuku sözleşme taslakçısısın. Kullanıcının verdiği kısa açıklamayı, profesyonel, dengeli ve Türk hukukuna uygun tek bir sözleşme maddesine dönüştür.
Sadece madde metnini yaz, başlık veya açıklama ekleme. Türkçe yanıt ver.";
            string userMessage = instruction;
            return await SendChatMessageAsync(systemPrompt, userMessage);
        }

        public async Task<string> SearchInContractAsync(string contractText, string question)
        {
            string systemPrompt = @"Verilen sözleşme metninde sorulan soruyu yanıtla.
Eğer sorunun cevabı sözleşmede varsa, ilgili maddeyi ve metni belirt.
Eğer cevap yoksa 'Bu bilgi sözleşmede bulunamadı' de.
Kısa ve net yanıt ver. Türkçe yanıt ver.";

            string userMessage = $"Sözleşme İçeriği:\n{contractText}\n\nSoru: {question}";
            return await SendChatMessageAsync(systemPrompt, userMessage);
        }

        public async Task<Dictionary<string, string>> ExtractFieldsAsync(string contractText, string contractType)
        {
            string systemPrompt = @"Sen bir sözleşme analiz uzmanısın. Verilen sözleşmeden yapılandırılmış bilgileri çıkar ve şu formatta JSON döndür:

{
  ""BaslangicTarihi"": ""Sözleşme başlangıç tarihi (gg.aa.yyyy veya Metin olarak)"",
  ""BitisTarihi"": ""Sözleşme bitiş tarihi"",
  ""Sure"": ""Süre (örn: 12 ay, 1 yıl, Belirsiz)"",
  ""FesihTuru"": ""Fesih türü (Olağan / Olağanüstü / Belirtilmemiş)"",
  ""FesihBildirimSuresi"": ""Fesih bildirim süresi (örn: 30 gün)"",
  ""Yenileme"": ""Yenileme koşulu (Otomatik / Manuel / Yok)"",
  ""YenilemeBildirimSuresi"": ""Yenileme bildirim süresi"",
  ""OdemeTutari"": ""Ödeme tutarı ve para birimi"",
  ""OdemeVadesi"": ""Ödeme vadesi"",
  ""GecikmeCezasi"": ""Gecikme cezası oranı veya tutarı"",
  ""CezaiSart"": ""Cezai şart koşulları"",
  ""Teminat"": ""Teminat türü ve tutarı"",
  ""SLA"": ""SLA koşulları (varsa)""
}

Eğer bir bilgi sözleşmede bulunamıyorsa ""Bulunamadı"" yaz. Türkçe yanıt ver. Sadece JSON döndür.";

            string userMessage = $"Sözleşme Türü: {contractType}\n\nSözleşme İçeriği:\n{contractText}";
            string response = await SendChatMessageAsync(systemPrompt, userMessage);

            return ParseExtractionJson(response);
        }

        private Dictionary<string, string> ParseExtractionJson(string response)
        {
            var result = new Dictionary<string, string>();
            string[] fieldNames = {
                "BaslangicTarihi", "BitisTarihi", "Sure", "FesihTuru",
                "FesihBildirimSuresi", "Yenileme", "YenilemeBildirimSuresi",
                "OdemeTutari", "OdemeVadesi", "GecikmeCezasi", "CezaiSart",
                "Teminat", "SLA"
            };

            try
            {
                var cleaned = CleanJsonResponse(response);
                using var doc = JsonDocument.Parse(cleaned);
                var root = doc.RootElement;

                foreach (var field in fieldNames)
                {
                    if (root.TryGetProperty(field, out var value))
                    {
                        result[field] = value.GetString() ?? "Bulunamadı";
                    }
                    else
                    {
                        result[field] = "Bulunamadı";
                    }
                }
            }
            catch (Exception ex)
            {
                Trace.WriteLine($"[AIService] Extraction JSON parse hatası: {ex.Message}");
                foreach (var field in fieldNames)
                {
                    result[field] = "Bulunamadı";
                }
            }

            return result;
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
                stream = false,
                temperature = 0
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
                return msgContent.GetString() ?? responseBody;

            return responseBody;
        }

        private string CleanJsonResponse(string response)
        {
            string cleaned = response.Trim();

            if (cleaned.StartsWith("```"))
            {
                int firstNewLine = cleaned.IndexOf('\n');
                if (firstNewLine >= 0)
                    cleaned = cleaned.Substring(firstNewLine + 1);
                int lastFence = cleaned.LastIndexOf("```");
                if (lastFence >= 0)
                    cleaned = cleaned.Substring(0, lastFence);
                cleaned = cleaned.Trim();
            }

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
