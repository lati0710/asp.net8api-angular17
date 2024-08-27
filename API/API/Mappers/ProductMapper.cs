using API.Dtos.Product;
using API.Models;

namespace API.Mappers
{
	public static class ProductMapper
	{
		public static ProductDto ToProductDto(this Product productModel)
		{
			return new ProductDto
			{
				Id = productModel.Id,
				ProductName = productModel.ProductName,
				Price = productModel.Price,
				Description = productModel.Description,
				CategoryId = productModel.CategoryId
			};
		}

		public static Product ToProductCreate(this CreateProductRequestDto productDto, int categoryId)
		{
			return new Product
			{
				ProductName = productDto.ProductName,
				Price = productDto.Price,
				Description = productDto.Description,
				CategoryId = categoryId
			};
		}

		public static Product ToProductUpdate(this UpdateProductRequestDto productDto)
		{
			return new Product
			{
				ProductName = productDto.ProductName,
				Price = productDto.Price,
				Description = productDto.Description,
				CategoryId = productDto.CategoryId ?? 0
			};
		}
	}
}
