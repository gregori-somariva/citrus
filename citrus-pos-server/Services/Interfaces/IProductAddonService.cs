using Citrus.Models;

namespace Citrus.Services.Interfaces
{
    public interface IProductAddonService
    {
        Task<ServiceResponse<ProductAddon>> GetByIdAsync(int id);
        Task<ServiceResponse<List<ProductAddon>>> GetAllAsync();
        Task<ServiceResponse<ProductAddon>> CreateAsync(ProductAddon addon);
        Task<ServiceResponse<ProductAddon>> UpdateAsync(ProductAddon addon);
        Task<ServiceResponse<bool>> DeleteAsync(int id);
    }
}