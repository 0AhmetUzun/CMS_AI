using System;

namespace ContractManagementSystem_CMS_.Models
{
    public class ExtractionChangeLog
    {
        public int ExtractionId { get; set; }
        public string FieldName { get; set; } = "";
        public string OldValue { get; set; } = "";
        public string NewValue { get; set; } = "";
        public DateTime ChangedAt { get; set; } = DateTime.Now;
        public bool IsChanged => OldValue != NewValue;
    }
}
