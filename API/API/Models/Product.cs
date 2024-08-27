using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
	[Table("Product")]
	public class Product
	{
		public int Id { get; set; }
		public string ProductName { get; set; } = string.Empty;
		public string Price { get; set; } = string.Empty;
		public string Description { get; set; } = string.Empty;
		public int? CategoryId { get; set; }
		public Category? Category { get; set; }
	}
}
