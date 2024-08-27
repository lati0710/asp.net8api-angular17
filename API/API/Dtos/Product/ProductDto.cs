namespace API.Dtos.Product
{
	public class ProductDto
	{
		public int Id { get; set; }
		public string ProductName { get; set; } = string.Empty;
		public string Price { get; set; } = string.Empty;
		public string Description { get; set; } = string.Empty;
		public int? CategoryId { get; set; }
	}
}
