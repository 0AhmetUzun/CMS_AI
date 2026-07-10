using System;

namespace ContractManagementSystem_CMS_.Models
{
    public class ContractListItem
    {
        public int Id { get; set; }
        public string FileName { get; set; } = "";
        public string? FilePath { get; set; }
        public string? TypeName { get; set; }
        public int RiskScore { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
