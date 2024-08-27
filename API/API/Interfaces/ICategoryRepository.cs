using API.Dtos.Category;
using API.Helpers;
using API.Models;

namespace API.Interfaces
{
	public interface ICategoryRepository
	{
		Task<List<Category>> GetAllAsync(QueryObject query);
		Task<Category?> GetByIdAsync(int id);
		Task<Category?> GetByNameAsync(string name);
		Task<Category> CreateAsync(Category categoryModel);
		Task<Category?> UpdateAsync(int id, UpdateCategoryRequestDto categoryDto);
		Task<Category?> DeleteAsync(int id);
		Task<bool> CategoryExists(int id);
	}
}
