using System.ComponentModel.DataAnnotations;

namespace API.Dtos.Product
{
	public class CreateProductRequestDto
	{
		[Required(ErrorMessage = "Nhập danh mục bạn ui")]
		[MaxLength(10, ErrorMessage = "Tên sản phẩm không quá 10 ký tự")]
		public string ProductName { get; set; } = string.Empty;
		[Required(ErrorMessage = "Nhập giá bạn ui")]
		public string Price { get; set; } = string.Empty;
		[Required(ErrorMessage = "Nhập mô tả bạn ui")]
		[MinLength(5, ErrorMessage = "Mô tả ít nhất 5 ký tự nha")]
		public string Description { get; set; } = string.Empty;
	}
}
