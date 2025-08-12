using Microsoft.EntityFrameworkCore;
using Citrus.Services.Interfaces;
using Citrus.Contexts;
using Citrus.Models;
using Citrus.Models.Dtos;

namespace Citrus.Services
{
    public class ProductCategoryService : IProductCategoryService
    {
        private readonly SqliteDbContext _context;
        public ProductCategoryService(SqliteDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<ProductCategory>> GetByIdAsync(int id)
        {
            var category = await _context.ProductCategories.FindAsync(id);
            if (category == null)
                return ServiceResponse<ProductCategory>.NotFound();
            return ServiceResponse<ProductCategory>.SuccessResponse(category);
        }

        public async Task<ServiceResponse<List<ProductCategoryDto>>> GetAllAsync()
        {
            var categories = await _context.ProductCategories.Include(c => c.Products).ToListAsync();

            var dtoList = categories.Select(c => new ProductCategoryDto
            {
                ProductCategoryId = c.ProductCategoryId,
                Name = c.Name,
                Products = c.Products.Select(p => new ProductDto
                {
                    ProductId = p.ProductId,
                    Name = p.Name,
                    Description = p.Description,
                    ImageUrl = p.ImageUrl,
                    ProductCategoryId = p.ProductCategoryId,
                    Price = p.Price,
                    Stock = p.Stock,
                    CreatedAt = p.CreatedAt,
                    UpdatedAt = p.UpdatedAt
                }).ToList()
            }).ToList();
            
            return ServiceResponse<List<ProductCategoryDto>>.SuccessResponse(dtoList);
        }

        public async Task<ServiceResponse<ProductCategory>> CreateAsync(ProductCategory category)
        {
            _context.ProductCategories.Add(category);
            await _context.SaveChangesAsync();
            return ServiceResponse<ProductCategory>.SuccessResponse(category);
        }

        public async Task<ServiceResponse<ProductCategory>> UpdateAsync(ProductCategory category)
        {
            var existing = await _context.ProductCategories.FindAsync(category.ProductCategoryId);
            if (existing == null)
                return ServiceResponse<ProductCategory>.NotFound();
            _context.Entry(existing).CurrentValues.SetValues(category);
            await _context.SaveChangesAsync();
            return ServiceResponse<ProductCategory>.SuccessResponse(category);
        }

        public async Task<ServiceResponse<bool>> DeleteAsync(int id)
        {
            var category = await _context.ProductCategories.FindAsync(id);
            if (category == null)
                return ServiceResponse<bool>.NotFound();
            _context.ProductCategories.Remove(category);
            await _context.SaveChangesAsync();
            return ServiceResponse<bool>.SuccessResponse(true);
        }
    }
}