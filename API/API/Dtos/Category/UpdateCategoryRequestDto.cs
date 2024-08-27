using System.ComponentModel.DataAnnotations;

namespace API.Dtos.Category
{
	public class UpdateCategoryRequestDto
	{
		[Required(ErrorMessage = "Nhập tên danh mục bạn ui")]
		[MaxLength(10, ErrorMessage = "Tên danh mục không quá 10 ký tự")]
		public string CategoryName { get; set; } = string.Empty;
		[Required(ErrorMessage = "Nhập mô tả bạn ui")]
		[MinLength(5, ErrorMessage = "Mô tả ít nhất 5 ký tự nha")]
		public string Description { get; set; } = string.Empty;
	}
}
