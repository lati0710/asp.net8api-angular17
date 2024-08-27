using API.Dtos.Product;
using API.Models;

namespace API.Dtos.Category
{
	public class CategoryDto
	{
		public int Id { get; set; }
		public string CategoryName { get; set; } = string.Empty;
		public string Description { get; set; } = string.Empty;

		public List<ProductDto> Products { get; set; }
	}
}
