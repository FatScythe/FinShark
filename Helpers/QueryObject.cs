namespace api.Helpers
{
    public class QueryObject
    {
        public string? CompanyName { get; set; } = null;
        public string? Symbol { get; set; } = null;
        public string? SortBy { get; set; } = null;
        public bool IsDescending { get; set; } = false;
        public int Page { get; set; } = 1;
        public int Limit { get; set; } = 20;
    }
}