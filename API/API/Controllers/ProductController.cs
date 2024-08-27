using API.Data;
using API.Dtos.Product;
using API.Helpers;
using API.Interfaces;
using API.Mappers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductController : ControllerBase
	{
		private readonly IProductRepository _proRepo;
		private readonly ICategoryRepository _categoryRepo;

		public ProductController(IProductRepository proRepo,
			ICategoryRepository categoryRepo)
        {
			_proRepo = proRepo;
			_categoryRepo = categoryRepo;
		}
		[HttpGet]
		public async Task<IActionResult> GetAll([FromQuery] ProductQueryObject query)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			var products = await _proRepo.GetAllAsync(query);
			var proDto = products.Select(p => p.ToProductDto());

			return Ok(proDto);
		}
		[HttpGet("{id:int}")]
		public async Task<IActionResult> GetById([FromRoute] int id)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			var product = await _proRepo.GetByIdAsync(id);

			if (product == null)
			{
				return NotFound("Khong tim thay id");
			}

			return Ok(product.ToProductDto());
		}
		[HttpPost("{categoryId:int}")]
		public async Task<IActionResult> Create([FromRoute] int categoryId,
			CreateProductRequestDto createDto)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			if (!await _categoryRepo.CategoryExists(categoryId))
			{
				return BadRequest("Danh muc khong ton tai");
			}

			var proModel = createDto.ToProductCreate(categoryId);

			await _proRepo.CreateAsync(proModel);

			return CreatedAtAction(nameof(GetById),
				new { id = proModel.Id }, proModel.ToProductDto());
		}
		[HttpPut]
		[Route("{id:int}")]
		public async Task<IActionResult> Update([FromRoute] int id,
			[FromBody] UpdateProductRequestDto updateDto)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			if (updateDto.CategoryId.HasValue && !await _categoryRepo.CategoryExists(updateDto.CategoryId.Value))
			{
				return BadRequest("Danh mục không tồn tại.");
			}

			var product = await _proRepo.UpdateAsync(id, updateDto.ToProductUpdate());

			if (product == null)
			{
				return NotFound("Không tìm thấy sản phẩm với id");
			}

			return Ok(product.ToProductDto());
		}
		[HttpDelete]
		[Route("{id:int}")]
		public async Task<IActionResult> Delete([FromRoute] int id)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			var proModel = await _proRepo.DeleteAsync(id);

			if(proModel == null)
			{
				return NotFound("San pham khong ton tai");
			}

			return Ok(proModel);
		}
	}
}
