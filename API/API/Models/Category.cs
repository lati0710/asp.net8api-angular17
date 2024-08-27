using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
	[Table("Category")]
	public class Category
	{
		public int Id { get; set; }
        public string CategoryName { get; set; } = string.Empty;
		public string Description { get; set; } = string.Empty ;
		public List<Product> Products { get; set; } = new List<Product>();
	}
}
