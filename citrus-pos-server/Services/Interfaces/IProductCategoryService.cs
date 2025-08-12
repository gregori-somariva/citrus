using Citrus.Models;
using Citrus.Models.Dtos;

namespace Citrus.Services.Interfaces
{
    public interface IProductCategoryService
    {
        Task<ServiceResponse<ProductCategory>> GetByIdAsync(int id);
        Task<ServiceResponse<List<ProductCategoryDto>>> GetAllAsync();
        Task<ServiceResponse<ProductCategory>> CreateAsync(ProductCategory category);
        Task<ServiceResponse<ProductCategory>> UpdateAsync(ProductCategory category);
        Task<ServiceResponse<bool>> DeleteAsync(int id);
    }
}