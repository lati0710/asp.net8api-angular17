using API.Helpers;
using API.Models;

namespace API.Interfaces
{
	public interface IProductRepository
	{
		Task<List<Product>> GetAllAsync(ProductQueryObject query);
		Task<Product?> GetByIdAsync(int id);
		Task<Product?> GetByNameAsync(string name);
		Task<Product> CreateAsync(Product productModel);
		Task<Product?> UpdateAsync(int id, Product productModel);
		Task<Product?> DeleteAsync(int id);
	}
}
