using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text.RegularExpressions;
using ContractManagementSystem_CMS_.Models;
using ContractManagementSystem_CMS_.Services;

namespace ContractManagementSystem_CMS_.Services
{
    public class AnalysisEngine
    {
        private readonly DatabaseService _dbService;

        public AnalysisEngine()
        {
            _dbService = new DatabaseService();
        }

        public AnalysisResult PerformAnalysis(string text, int typeId)
        {
            var result = new AnalysisResult
            {
                TotalScore = 100,
                Details = new List<AnalysisDetail>()
            };

            if (string.IsNullOrWhiteSpace(text)) return result;

            try
            {
                var activeRules = _dbService.GetRulesByTypeId(typeId);
                if (activeRules == null || activeRules.Count == 0) return result;

                foreach (var rule in activeRules)
                {
                    if (string.IsNullOrWhiteSpace(rule.Pattern)) continue;

                    bool isPatternFound = Regex.IsMatch(text, rule.Pattern);

                    var detail = new AnalysisDetail
                    {
                        RuleDescription = rule.RuleDescription,
                        Pattern = rule.Pattern,
                        BoyaRengi = Color.Empty
                    };

                    if (rule.IsForbidden)
                    {
                        if (isPatternFound)
                        {
                            detail.Status = "Yasaklı Madde Bulundu";
                            detail.BoyaRengi = Color.Salmon;
                            result.TotalScore -= rule.Severity;
                        }
                        else
                        {
                            detail.Status = "Yasaklı Madde Rastlanmadı";
                            detail.BoyaRengi = Color.LightGreen;
                        }
                    }
                    else
                    {
                        if (isPatternFound)
                        {
                            detail.Status = "Zorunlu Madde Mevcut";
                            detail.BoyaRengi = Color.LightGreen;
                        }
                        else
                        {
                            detail.Status = "Zorunlu Madde Eksik";
                            result.BoyaRengi = Color.Salmon;
                            result.TotalScore -= rule.Severity;
                        }
                    }

                    result.Details.Add(detail);
                }

                if (result.TotalScore < 0) result.TotalScore = 0;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine($"[AnalysisEngine] Hata: {ex.Message}", typeof(AnalysisEngine).FullName);
                throw new InvalidOperationException("Analiz işlemi başarısız: " + ex.Message, ex);
            }

            return result;
        }
    }

    public class AnalysisResult
    {
        public List<AnalysisDetail> Details { get; set; } = null!;
        public int TotalScore { get; set; }
        public Color BoyaRengi { get; set; }
    }

    public class AnalysisDetail
    {
        public string RuleDescription { get; set; } = null!;
        public string Pattern { get; set; } = null!;
        public int Score { get; set; }
        public string Status { get; set; } = null!;
        public bool IsFound { get; set; }
        public bool IsForbidden { get; set; }
        public Color BoyaRengi { get; set; }
    }
}
