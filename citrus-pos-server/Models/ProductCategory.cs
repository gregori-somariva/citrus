using Citrus.Models;

namespace Citrus.Models
{
    public class ProductCategory
    {
        public int ProductCategoryId { get; set; }
        public required string Name { get; set; }

        public List<Product> Products { get; set; } = [];
    }
}