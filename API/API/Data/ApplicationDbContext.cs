using API.Models;
using Microsoft.EntityFrameworkCore;
using API.Dtos.Category;
using API.Dtos.Product;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace API.Data
{
	public class ApplicationDbContext : IdentityDbContext<Account>
	{
		public ApplicationDbContext(DbContextOptions options) : base(options)
		{
		}
		public DbSet<Category> Categories { get; set; }
		public DbSet<Product> Products { get; set; }
	    public DbSet<API.Dtos.Category.CategoryDto> CategoryDto { get; set; } = default!;
	    public DbSet<API.Dtos.Product.ProductDto> ProductDto { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

			List<IdentityRole> roles = new List<IdentityRole>
			{
				new IdentityRole
				{
					Name = "Admin",
					NormalizedName = "ADMIN"
				},
                new IdentityRole
                {
                    Name = "User",
                    NormalizedName = "USER"
                },
            };
			builder.Entity<IdentityRole>().HasData(roles);
        }
    }
}
