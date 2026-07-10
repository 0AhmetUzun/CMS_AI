using System;

namespace ContractManagementSystem_CMS_.Models
{
    public class ContractExtraction
    {
        public int Id { get; set; }
        public int ContractId { get; set; }
        public string FieldName { get; set; } = "";
        public string FieldValue { get; set; } = "";
        public string? PreviousValue { get; set; }
        public bool IsManuallyEdited { get; set; }
        public DateTime LastModifiedAt { get; set; } = DateTime.Now;
    }
}
