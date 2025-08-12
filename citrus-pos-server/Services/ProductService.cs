using Microsoft.EntityFrameworkCore;

using Citrus.Services.Interfaces;
using Citrus.Contexts;
using Citrus.Models;
using Citrus.Models.Dtos;

namespace Citrus.Services
{
    public class ProductService : IProductService
    {
        private readonly SqliteDbContext _context;
        public ProductService(SqliteDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<Product>> GetByIdAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
                return ServiceResponse<Product>.NotFound();
            return ServiceResponse<Product>.SuccessResponse(product);
        }

        public async Task<ServiceResponse<List<ProductDto>>> GetAllAsync()
        {
            var products = await _context.Products.Include(p => p.ProductCategory).ToListAsync();

            var dtos = products.Select(p => new ProductDto
            {
                ProductId = p.ProductId,
                Name = p.Name,
                Description = p.Description,
                ImageUrl = p.ImageUrl,
                ProductCategoryId = p.ProductCategoryId,
                Price = p.Price,
                Stock = p.Stock,
                CreatedAt = p.CreatedAt,
                UpdatedAt = p.UpdatedAt,
                ProductCategory = p.ProductCategory == null ? null : new ProductCategoryDto
                {
                    ProductCategoryId = p.ProductCategory.ProductCategoryId,
                    Name = p.ProductCategory.Name
                }
            }).ToList();
            
            return ServiceResponse<List<ProductDto>>.SuccessResponse(dtos);
        }

        public async Task<ServiceResponse<Product>> CreateAsync(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return ServiceResponse<Product>.SuccessResponse(product);
        }

        public async Task<ServiceResponse<Product>> UpdateAsync(Product product)
        {
            var existing = await _context.Products.FindAsync(product.ProductId);
            if (existing == null)
                return ServiceResponse<Product>.NotFound();
            _context.Entry(existing).CurrentValues.SetValues(product);
            await _context.SaveChangesAsync();
            return ServiceResponse<Product>.SuccessResponse(product);
        }

        public async Task<ServiceResponse<bool>> DeleteAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
                return ServiceResponse<bool>.NotFound();
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return ServiceResponse<bool>.SuccessResponse(true);
        }
    }
}