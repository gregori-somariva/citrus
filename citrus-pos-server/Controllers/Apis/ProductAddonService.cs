
using Microsoft.AspNetCore.Mvc;
using Citrus.Services.Interfaces;
using Citrus.Models;

namespace Citrus.Controllers.Apis
{
	[ApiController]
	[Route("api/[controller]")]
	public class ProductAddonController : ControllerBase
	{
		private readonly IProductAddonService _productAddonService;
		public ProductAddonController(IProductAddonService productAddonService)
		{
			_productAddonService = productAddonService;
		}

		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var response = await _productAddonService.GetAllAsync();
			return Ok(response);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(int id)
		{
			var response = await _productAddonService.GetByIdAsync(id);
			if (!response.Success)
				return NotFound(response);
			return Ok(response);
		}

		[HttpPost]
		public async Task<IActionResult> Create([FromBody] ProductAddon addon)
		{
			var response = await _productAddonService.CreateAsync(addon);
			return CreatedAtAction(nameof(GetById), new { id = addon.ProductAddonId }, response);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> Update(int id, [FromBody] ProductAddon addon)
		{
			if (id != addon.ProductAddonId)
				return BadRequest(ServiceResponse<ProductAddon>.ValidationError("ID mismatch."));
			var response = await _productAddonService.UpdateAsync(addon);
			if (!response.Success)
				return NotFound(response);
			return Ok(response);
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			var response = await _productAddonService.DeleteAsync(id);
			if (!response.Success)
				return NotFound(response);
			return Ok(response);
		}
	}
}
