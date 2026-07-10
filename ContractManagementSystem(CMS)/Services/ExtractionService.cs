using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContractManagementSystem_CMS_.Models;

namespace ContractManagementSystem_CMS_.Services
{
    public class ExtractionService
    {
        private readonly DatabaseService _dbService;
        private readonly AIService _aiService;

        public ExtractionService()
        {
            _dbService = new DatabaseService();
            _aiService = new AIService();
        }

        public List<ContractExtraction> GetExtractions(int contractId)
        {
            return _dbService.GetExtractions(contractId);
        }

        public ContractExtraction? GetExtraction(int contractId, string fieldName)
        {
            return _dbService.GetExtraction(contractId, fieldName);
        }

        public List<ExtractionChangeLog> SaveExtractionsWithChanges(int contractId, Dictionary<string, string> newValues)
        {
            var changes = new List<ExtractionChangeLog>();
            var existingExtractions = _dbService.GetExtractions(contractId);

            foreach (var kvp in newValues)
            {
                var existing = existingExtractions.FirstOrDefault(e => e.FieldName == kvp.Key);
                var change = new ExtractionChangeLog
                {
                    FieldName = kvp.Key,
                    OldValue = existing?.FieldValue ?? "(Boş)",
                    NewValue = kvp.Value,
                    ChangedAt = DateTime.Now
                };

                if (change.IsChanged)
                {
                    changes.Add(change);
                }

                _dbService.SaveExtraction(contractId, kvp.Key, kvp.Value);
            }

            return changes;
        }

        public void UndoChange(int extractionId)
        {
            _dbService.UndoExtraction(extractionId);
        }

        public async Task<Dictionary<string, string>> ExtractFromDocumentAsync(string content, string contractType)
        {
            try
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

                string userMessage = $"Sözleşme Türü: {contractType}\n\nSözleşme İçeriği:\n{content}";
                string response = await _aiService.SearchInContractAsync(content, systemPrompt + "\n\n" + userMessage);

                return ParseExtractionResponse(response);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine($"[ExtractionService] AI çıkarım hatası: {ex.Message}");
                return GetDefaultExtractions();
            }
        }

        private Dictionary<string, string> ParseExtractionResponse(string response)
        {
            var result = new Dictionary<string, string>();

            try
            {
                string cleaned = response.Trim();
                int jsonStart = cleaned.IndexOf('{');
                int jsonEnd = cleaned.LastIndexOf('}');
                
                if (jsonStart >= 0 && jsonEnd > jsonStart)
                {
                    cleaned = cleaned.Substring(jsonStart, jsonEnd - jsonStart + 1);
                }

                using var doc = System.Text.Json.JsonDocument.Parse(cleaned);
                var root = doc.RootElement;

                string[] fieldNames = {
                    "BaslangicTarihi", "BitisTarihi", "Sure", "FesihTuru",
                    "FesihBildirimSuresi", "Yenileme", "YenilemeBildirimSuresi",
                    "OdemeTutari", "OdemeVadesi", "GecikmeCezasi", "CezaiSart",
                    "Teminat", "SLA"
                };

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
                System.Diagnostics.Trace.WriteLine($"[ExtractionService] JSON parse hatası: {ex.Message}");
                return GetDefaultExtractions();
            }

            return result;
        }

        private Dictionary<string, string> GetDefaultExtractions()
        {
            return new Dictionary<string, string>
            {
                { "BaslangicTarihi", "Bulunamadı" },
                { "BitisTarihi", "Bulunamadı" },
                { "Sure", "Bulunamadı" },
                { "FesihTuru", "Bulunamadı" },
                { "FesihBildirimSuresi", "Bulunamadı" },
                { "Yenileme", "Bulunamadı" },
                { "YenilemeBildirimSuresi", "Bulunamadı" },
                { "OdemeTutari", "Bulunamadı" },
                { "OdemeVadesi", "Bulunamadı" },
                { "GecikmeCezasi", "Bulunamadı" },
                { "CezaiSart", "Bulunamadı" },
                { "Teminat", "Bulunamadı" },
                { "SLA", "Bulunamadı" }
            };
        }

        public string GetFieldDisplayName(string fieldName)
        {
            return fieldName switch
            {
                "BaslangicTarihi" => "📅 Başlangıç Tarihi",
                "BitisTarihi" => "📅 Bitiş Tarihi",
                "Sure" => "⏱️ Süre",
                "FesihTuru" => "📝 Fesih Türü",
                "FesihBildirimSuresi" => "⏰ Fesih Bildirim Süresi",
                "Yenileme" => "🔄 Yenileme",
                "YenilemeBildirimSuresi" => "⏰ Yenileme Bildirim Süresi",
                "OdemeTutari" => "💰 Ödeme Tutarı",
                "OdemeVadesi" => "📅 Ödeme Vadesi",
                "GecikmeCezasi" => "⚠️ Gecikme Cezası",
                "CezaiSart" => "⚖️ Cezai Şart",
                "Teminat" => "🛡️ Teminat",
                "SLA" => "📋 SLA",
                _ => fieldName
            };
        }
    }
}
