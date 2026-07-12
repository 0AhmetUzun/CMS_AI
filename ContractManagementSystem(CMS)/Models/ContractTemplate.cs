namespace ContractManagementSystem_CMS_.Models
{
    public class ContractTemplate
    {
        public int Id { get; set; }
        public string TemplateName { get; set; } = string.Empty;
        public string? TemplateType { get; set; }
        public string Content { get; set; } = string.Empty;
        public bool IsBuiltIn { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
