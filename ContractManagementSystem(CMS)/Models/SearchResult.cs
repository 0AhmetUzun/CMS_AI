namespace ContractManagementSystem_CMS_.Models
{
    public class SearchResult
    {
        public int Index { get; set; }
        public string MatchedText { get; set; } = null!;
        public string Context { get; set; } = null!;
        public int Position { get; set; }
        public int LineNumber { get; set; }
        public string SearchType { get; set; } = null!;
    }
}