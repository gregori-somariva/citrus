
using Microsoft.AspNetCore.Mvc;
using Citrus.Services.Interfaces;
using Citrus.Models;
using Citrus.Models.Dtos;

namespace Citrus.Controllers.Apis
{
	[ApiController]
	[Route("api/[controller]")]
	public class ProductController : ControllerBase
	{
		private readonly IProductService _productService;
		public ProductController(IProductService productService)
		{
			_productService = productService;
		}

		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var response = await _productService.GetAllAsync();
			return Ok(response);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(int id)
		{
			var response = await _productService.GetByIdAsync(id);
			if (!response.Success)
				return NotFound(response);
			return Ok(response);
		}

		[HttpPost]
		public async Task<IActionResult> Create([FromBody] Product product)
		{
			var response = await _productService.CreateAsync(product);
			return CreatedAtAction(nameof(GetById), new { id = product.ProductId }, response);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> Update(int id, [FromBody] Product product)
		{
			if (id != product.ProductId)
				return BadRequest(ServiceResponse<Product>.ValidationError("ID mismatch."));
			var response = await _productService.UpdateAsync(product);
			if (!response.Success)
				return NotFound(response);
			return Ok(response);
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			var response = await _productService.DeleteAsync(id);
			if (!response.Success)
				return NotFound(response);
			return Ok(response);
		}
	}
}
