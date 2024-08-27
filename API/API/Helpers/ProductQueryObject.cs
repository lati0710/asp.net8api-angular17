namespace API.Helpers
{
    public class ProductQueryObject
    {
        public string? productName { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 20;
    }
}
