using System.Collections.Generic;

namespace ContractManagementSystem_CMS_.Models
{
    public class ContractSummaryResult
    {
        public string Purpose { get; set; } = "";
        public string Parties { get; set; } = "";
        public string Duration { get; set; } = "";
        public string Termination { get; set; } = "";
        public string Payment { get; set; } = "";
        public List<string> KeyObligations { get; set; } = new();
        public List<string> Risks { get; set; } = new();
        public string RawResponse { get; set; } = "";
    }
}
