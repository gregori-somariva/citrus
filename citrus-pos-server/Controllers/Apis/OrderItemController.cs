
using Microsoft.AspNetCore.Mvc;
using Citrus.Services.Interfaces;
using Citrus.Models;

namespace Citrus.Controllers.Apis
{
	[ApiController]
	[Route("api/[controller]")]
	public class OrderItemController : ControllerBase
	{
		private readonly IOrderItemService _orderItemService;
		public OrderItemController(IOrderItemService orderItemService)
		{
			_orderItemService = orderItemService;
		}

		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var response = await _orderItemService.GetAllAsync();
			return Ok(response);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(int id)
		{
			var response = await _orderItemService.GetByIdAsync(id);
			if (!response.Success)
				return NotFound(response);
			return Ok(response);
		}

		[HttpPost]
		public async Task<IActionResult> Create([FromBody] OrderItem item)
		{
			var response = await _orderItemService.CreateAsync(item);
			return CreatedAtAction(nameof(GetById), new { id = item.OrderItemId }, response);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> Update(int id, [FromBody] OrderItem item)
		{
			if (id != item.OrderItemId)
				return BadRequest(ServiceResponse<OrderItem>.ValidationError("ID mismatch."));
			var response = await _orderItemService.UpdateAsync(item);
			if (!response.Success)
				return NotFound(response);
			return Ok(response);
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			var response = await _orderItemService.DeleteAsync(id);
			if (!response.Success)
				return NotFound(response);
			return Ok(response);
		}
	}
}
