using API.Dtos.Category;
using API.Models;

namespace API.Mappers
{
	public static class CategoryMapper
	{
		public static CategoryDto ToCategoryDto(this Category categoryModel)
		{
			return new CategoryDto
			{
				Id = categoryModel.Id,
				CategoryName = categoryModel.CategoryName,
				Description = categoryModel.Description,
				Products = categoryModel.Products.Select(p => p.ToProductDto()).ToList()
			};
		}

		public static Category ToCategoryCreateDto(this CreateCategoryRequestDto categoryDto)
		{
			return new Category
			{
				CategoryName = categoryDto.CategoryName,
				Description = categoryDto.Description
			};
		}
	}
}
