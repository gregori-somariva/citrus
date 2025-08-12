using Citrus.Models;
using Citrus.Models.Dtos;

namespace Citrus.Services.Interfaces
{
    public interface IProductService
    {
        Task<ServiceResponse<Product>> GetByIdAsync(int id);
        Task<ServiceResponse<List<ProductDto>>> GetAllAsync();
        Task<ServiceResponse<Product>> CreateAsync(Product product);
        Task<ServiceResponse<Product>> UpdateAsync(Product product);
        Task<ServiceResponse<bool>> DeleteAsync(int id);
    }
}