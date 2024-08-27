using API.Data;
using API.Dtos.Category;
using API.Helpers;
using API.Interfaces;
using API.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace API.Repository
{
	public class CategoryRepository : ICategoryRepository
	{
		private readonly ApplicationDbContext _context;

		public CategoryRepository(ApplicationDbContext context)
        {
			_context = context;
		}
        public Task<bool> CategoryExists(int id)
		{
			return _context.Categories.AnyAsync(c => c.Id == id);
		}

		public async Task<Category> CreateAsync(Category categoryModel)
		{
			await _context.Categories.AddAsync(categoryModel);
			await _context.SaveChangesAsync();

			return categoryModel;
		}

		public async Task<Category?> DeleteAsync(int id)
		{
			var cateModel = await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);

			if (cateModel == null)
			{
				return null;
			}

			_context.Categories.Remove(cateModel);
			await _context.SaveChangesAsync();

			return cateModel;

		}

		public async Task<List<Category>> GetAllAsync(QueryObject query)
		{
			var categories = _context.Categories.Include(p => p.Products).AsQueryable();

			if(!string.IsNullOrWhiteSpace(query.categoryName))
			{
				categories = categories.Where(c => c.CategoryName.Contains(query.categoryName));	
			}

			return await categories.ToListAsync();
		}

		public async Task<Category?> GetByIdAsync(int id)
		{
			return await _context.Categories.Include(p => p.Products)
				.FirstOrDefaultAsync(i => i.Id == id);
		}

		public Task<Category?> GetByNameAsync(string name)
		{
			throw new NotImplementedException();
		}

		public async Task<Category?> UpdateAsync(int id, UpdateCategoryRequestDto categoryDto)
		{
			var existingCate = await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);

			if (existingCate == null)
			{
				return null;
			}

			existingCate.CategoryName = categoryDto.CategoryName;
			existingCate.Description = categoryDto.Description;

			await _context.SaveChangesAsync();

			return existingCate;
		}
	}
}
