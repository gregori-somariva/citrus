
using Microsoft.AspNetCore.Mvc;
using Citrus.Services.Interfaces;
using Citrus.Models;

namespace Citrus.Controllers.Apis
{
	[ApiController]
	[Route("api/[controller]")]
	public class OrderController : ControllerBase
	{
		private readonly IOrderService _orderService;
		public OrderController(IOrderService orderService)
		{
			_orderService = orderService;
		}

		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var response = await _orderService.GetAllAsync();
			return Ok(response);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(int id)
		{
			var response = await _orderService.GetByIdAsync(id);
			if (!response.Success)
				return NotFound(response);
			return Ok(response);
		}

		[HttpPost]
		public async Task<IActionResult> Create([FromBody] Order order)
		{
			var response = await _orderService.CreateAsync(order);
			return CreatedAtAction(nameof(GetById), new { id = order.OrderId }, response);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> Update(int id, [FromBody] Order order)
		{
			if (id != order.OrderId)
				return BadRequest(ServiceResponse<Order>.ValidationError("ID mismatch."));
			var response = await _orderService.UpdateAsync(order);
			if (!response.Success)
				return NotFound(response);
			return Ok(response);
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			var response = await _orderService.DeleteAsync(id);
			if (!response.Success)
				return NotFound(response);
			return Ok(response);
		}
	}
}
