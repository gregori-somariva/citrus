using Microsoft.AspNetCore.Mvc;
using Citrus.Services.Interfaces;
using Citrus.Models;

namespace Citrus.Controllers.Apis
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductCategoryController : ControllerBase
    {
        private readonly IProductCategoryService _service;
        public ProductCategoryController(IProductCategoryService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<ProductCategory>>>> GetAll()
        {
            var result = await _service.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<ProductCategory>>> GetById(int id)
        {
            var result = await _service.GetByIdAsync(id);
            if (!result.Success)
                return NotFound(result);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<ProductCategory>>> Create(ProductCategory category)
        {
            var result = await _service.CreateAsync(category);
            return CreatedAtAction(nameof(GetById), new { id = result.Data?.ProductCategoryId }, result);
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<ProductCategory>>> Update(ProductCategory category)
        {
            var result = await _service.UpdateAsync(category);
            if (!result.Success)
                return NotFound(result);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<bool>>> Delete(int id)
        {
            var result = await _service.DeleteAsync(id);
            if (!result.Success)
                return NotFound(result);
            return Ok(result);
        }
    }
}