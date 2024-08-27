using System.ComponentModel.DataAnnotations;

namespace API.Dtos.Category
{
	public class CreateCategoryRequestDto
	{
		[Required(ErrorMessage = "Nhập danh mục bạn ui")]
		[MaxLength(10, ErrorMessage = "Tên danh mục không quá 10 ký tự")]
		public string CategoryName { get; set; } = string.Empty;
		[Required(ErrorMessage = "Nhập mô tả đi bạn")]
		[MinLength(5, ErrorMessage = "Mô tả ít nhất 5 ký tự nha")]
		public string Description { get; set; } = string.Empty;
	}
}
