using Microsoft.EntityFrameworkCore;

using Citrus.Services.Interfaces;
using Citrus.Contexts;
using Citrus.Models;

namespace Citrus.Services
{
    public class OrderService : IOrderService
    {
        private readonly SqliteDbContext _context;
        public OrderService(SqliteDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<Order>> GetByIdAsync(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order == null)
                return ServiceResponse<Order>.NotFound();
            return ServiceResponse<Order>.SuccessResponse(order);
        }

        public async Task<ServiceResponse<List<Order>>> GetAllAsync()
        {
            var orders = await _context.Orders.ToListAsync();
            return ServiceResponse<List<Order>>.SuccessResponse(orders);
        }

        public async Task<ServiceResponse<Order>> CreateAsync(Order order)
        {
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
            return ServiceResponse<Order>.SuccessResponse(order);
        }

        public async Task<ServiceResponse<Order>> UpdateAsync(Order order)
        {
            var existing = await _context.Orders.FindAsync(order.OrderId);
            if (existing == null)
                return ServiceResponse<Order>.NotFound();
            _context.Entry(existing).CurrentValues.SetValues(order);
            await _context.SaveChangesAsync();
            return ServiceResponse<Order>.SuccessResponse(order);
        }

        public async Task<ServiceResponse<bool>> DeleteAsync(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order == null)
                return ServiceResponse<bool>.NotFound();
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
            return ServiceResponse<bool>.SuccessResponse(true);
        }
    }
}