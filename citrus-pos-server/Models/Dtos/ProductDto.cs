namespace Citrus.Models.Dtos
{
    public class ProductDto
    {
        public int ProductId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public int ProductCategoryId { get; set; }
        public decimal Price { get; set; }
        public int? Stock { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public ProductCategoryDto? ProductCategory { get; set; }
        public List<ProductAddonDto>? ProductAddons { get; set; }
    }
}
