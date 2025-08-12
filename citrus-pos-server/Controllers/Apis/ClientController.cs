
using Microsoft.AspNetCore.Mvc;
using Citrus.Services.Interfaces;
using Citrus.Models;

namespace Citrus.Controllers.Apis
{
	[ApiController]
	[Route("api/[controller]")]
	public class ClientController : ControllerBase
	{
		private readonly IClientService _clientService;
		public ClientController(IClientService clientService)
		{
			_clientService = clientService;
		}

		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var response = await _clientService.GetAllAsync();
			return Ok(response);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(int id)
		{
			var response = await _clientService.GetByIdAsync(id);
			if (!response.Success)
				return NotFound(response);
			return Ok(response);
		}

		[HttpPost]
		public async Task<IActionResult> Create([FromBody] Client client)
		{
			var response = await _clientService.CreateAsync(client);
			return CreatedAtAction(nameof(GetById), new { id = client.ClientId }, response);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> Update(int id, [FromBody] Client client)
		{
			if (id != client.ClientId)
				return BadRequest(ServiceResponse<Client>.ValidationError("ID mismatch."));
			var response = await _clientService.UpdateAsync(client);
			if (!response.Success)
				return NotFound(response);
			return Ok(response);
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			var response = await _clientService.DeleteAsync(id);
			if (!response.Success)
				return NotFound(response);
			return Ok(response);
		}
	}
}
