using API.Data;
using API.Dtos.Category;
using API.Helpers;
using API.Interfaces;
using API.Mappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CategoryController : ControllerBase
	{
		private readonly ApplicationDbContext _context;
		private readonly ICategoryRepository _cateRepo;

		public CategoryController(ApplicationDbContext context,
			ICategoryRepository cateRepo)
        {
			_context = context;
			_cateRepo = cateRepo;
		}
		[HttpGet]
		//[Authorize]
		public async Task<IActionResult> GetAll([FromQuery] QueryObject query)
		{
			if(!ModelState.IsValid)
				return BadRequest(ModelState);

			var categories = await _cateRepo.GetAllAsync(query);
			var cateDto = categories.Select(c => c.ToCategoryDto());

			return Ok(categories);
		}
		[HttpGet("{id:int}")]
		public async Task<IActionResult> GetById([FromRoute] int id)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			var category = await _cateRepo.GetByIdAsync(id);

			if (category == null)
			{
				return NotFound("Khong tim thay id");
			}

			return Ok(category.ToCategoryDto());
		}
		[HttpPost]
		public async Task<IActionResult> Create([FromBody] CreateCategoryRequestDto createDto)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			var cateModel = createDto.ToCategoryCreateDto();

			await _cateRepo.CreateAsync(cateModel);

			return CreatedAtAction(nameof(GetById), 
				new {id = cateModel.Id }, cateModel.ToCategoryDto());
		}
		[HttpPut]
		[Route("{id:int}")]
		public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateCategoryRequestDto updateDto)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			var cateModel = await _cateRepo.UpdateAsync(id, updateDto);

			if (cateModel == null)
			{
				return NotFound("Khong tim thay Id");
			}

			return Ok(cateModel.ToCategoryDto());
		}
		[HttpDelete]
		[Route("{id:int}")]
		public async Task<IActionResult> Delete([FromRoute] int id)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			var cateModel = await _cateRepo.DeleteAsync(id);

			if(cateModel == null)
			{
				return NotFound("Khong tim thay Id");
			}

			return NoContent();
		}
	}
}
