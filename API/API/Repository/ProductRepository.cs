using API.Data;
using API.Helpers;
using API.Interfaces;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Repository
{
	public class ProductRepository : IProductRepository
	{
		private readonly ApplicationDbContext _context;

		public ProductRepository(ApplicationDbContext context)
		{
			_context = context;
		}
		public async Task<Product> CreateAsync(Product productModel)
		{
			await _context.Products.AddAsync(productModel);
			await _context.SaveChangesAsync();

			return productModel;
		}

		public async Task<Product?> DeleteAsync(int id)
		{
			var proModel = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);

			if (proModel == null)
			{
				return null;
			}

			_context.Products.Remove(proModel);
			await _context.SaveChangesAsync();

			return proModel;
		}
		public async Task<List<Product>> GetAllAsync(ProductQueryObject query)
		{
			var products = _context.Products.AsQueryable();

			if (!string.IsNullOrWhiteSpace(query.productName))
			{
				products = products.Where(p => p.ProductName.Contains(query.productName));
			}

			var skipNumber = (query.PageNumber - 1) * query.PageSize;


			return await products.Skip(skipNumber).Take(query.PageSize).ToListAsync();
		}

		public async Task<Product?> GetByIdAsync(int id)
		{
            return await _context.Products
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == id);
        }

		public async Task<Product?> GetByNameAsync(string name)
		{
            return await _context.Products
                .AsNoTracking() 
                .FirstOrDefaultAsync(p => p.ProductName == name);
        }

		public async Task<Product?> UpdateAsync(int id, Product productModel)
		{
			var existingProduct = await _context.Products.FindAsync(id);

			if (existingProduct == null)
			{
				return null;
			}

			existingProduct.ProductName = productModel.ProductName;
			existingProduct.Price = productModel.Price;
			existingProduct.Description = productModel.Description;
			existingProduct.CategoryId = productModel.CategoryId;

			await _context.SaveChangesAsync();

			return existingProduct;
		}
	}
}
