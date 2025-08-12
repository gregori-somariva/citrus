using Microsoft.EntityFrameworkCore;

using Citrus.Services.Interfaces;
using Citrus.Contexts;
using Citrus.Models;

namespace Citrus.Services
{
    public class ProductAddonService : IProductAddonService
    {
        private readonly SqliteDbContext _context;
        public ProductAddonService(SqliteDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<ProductAddon>> GetByIdAsync(int id)
        {
            var addon = await _context.ProductAddons.FindAsync(id);
            if (addon == null)
                return ServiceResponse<ProductAddon>.NotFound();
            return ServiceResponse<ProductAddon>.SuccessResponse(addon);
        }

        public async Task<ServiceResponse<List<ProductAddon>>> GetAllAsync()
        {
            var addons = await _context.ProductAddons.ToListAsync();
            return ServiceResponse<List<ProductAddon>>.SuccessResponse(addons);
        }

        public async Task<ServiceResponse<ProductAddon>> CreateAsync(ProductAddon addon)
        {
            _context.ProductAddons.Add(addon);
            await _context.SaveChangesAsync();
            return ServiceResponse<ProductAddon>.SuccessResponse(addon);
        }

        public async Task<ServiceResponse<ProductAddon>> UpdateAsync(ProductAddon addon)
        {
            var existing = await _context.ProductAddons.FindAsync(addon.ProductAddonId);
            if (existing == null)
                return ServiceResponse<ProductAddon>.NotFound();
            _context.Entry(existing).CurrentValues.SetValues(addon);
            await _context.SaveChangesAsync();
            return ServiceResponse<ProductAddon>.SuccessResponse(addon);
        }

        public async Task<ServiceResponse<bool>> DeleteAsync(int id)
        {
            var addon = await _context.ProductAddons.FindAsync(id);
            if (addon == null)
                return ServiceResponse<bool>.NotFound();
            _context.ProductAddons.Remove(addon);
            await _context.SaveChangesAsync();
            return ServiceResponse<bool>.SuccessResponse(true);
        }
    }
}