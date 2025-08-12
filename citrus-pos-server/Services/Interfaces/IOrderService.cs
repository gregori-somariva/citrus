using Citrus.Models;

namespace Citrus.Services.Interfaces
{
    public interface IOrderService
    {
        Task<ServiceResponse<Order>> GetByIdAsync(int id);
        Task<ServiceResponse<List<Order>>> GetAllAsync();
        Task<ServiceResponse<Order>> CreateAsync(Order order);
        Task<ServiceResponse<Order>> UpdateAsync(Order order);
        Task<ServiceResponse<bool>> DeleteAsync(int id);
    }
}