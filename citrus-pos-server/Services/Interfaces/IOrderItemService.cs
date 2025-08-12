using Citrus.Models;

namespace Citrus.Services.Interfaces
{
    public interface IOrderItemService
    {
        Task<ServiceResponse<OrderItem>> GetByIdAsync(int id);
        Task<ServiceResponse<List<OrderItem>>> GetAllAsync();
        Task<ServiceResponse<OrderItem>> CreateAsync(OrderItem item);
        Task<ServiceResponse<OrderItem>> UpdateAsync(OrderItem item);
        Task<ServiceResponse<bool>> DeleteAsync(int id);
    }
}