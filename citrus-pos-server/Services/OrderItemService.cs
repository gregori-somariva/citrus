using Microsoft.EntityFrameworkCore;

using Citrus.Services.Interfaces;
using Citrus.Contexts;
using Citrus.Models;


namespace Citrus.Services
{
    public class OrderItemService : IOrderItemService
    {
        private readonly SqliteDbContext _context;
        public OrderItemService(SqliteDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<OrderItem>> GetByIdAsync(int id)
        {
            var item = await _context.OrderItems.FindAsync(id);
            if (item == null)
                return ServiceResponse<OrderItem>.NotFound();
            return ServiceResponse<OrderItem>.SuccessResponse(item);
        }

        public async Task<ServiceResponse<List<OrderItem>>> GetAllAsync()
        {
            var items = await _context.OrderItems.ToListAsync();
            return ServiceResponse<List<OrderItem>>.SuccessResponse(items);
        }

        public async Task<ServiceResponse<OrderItem>> CreateAsync(OrderItem item)
        {
            _context.OrderItems.Add(item);
            await _context.SaveChangesAsync();
            return ServiceResponse<OrderItem>.SuccessResponse(item);
        }

        public async Task<ServiceResponse<OrderItem>> UpdateAsync(OrderItem item)
        {
            var existing = await _context.OrderItems.FindAsync(item.OrderItemId);
            if (existing == null)
                return ServiceResponse<OrderItem>.NotFound();
            _context.Entry(existing).CurrentValues.SetValues(item);
            await _context.SaveChangesAsync();
            return ServiceResponse<OrderItem>.SuccessResponse(item);
        }

        public async Task<ServiceResponse<bool>> DeleteAsync(int id)
        {
            var item = await _context.OrderItems.FindAsync(id);
            if (item == null)
                return ServiceResponse<bool>.NotFound();
            _context.OrderItems.Remove(item);
            await _context.SaveChangesAsync();
            return ServiceResponse<bool>.SuccessResponse(true);
        }
    }
}