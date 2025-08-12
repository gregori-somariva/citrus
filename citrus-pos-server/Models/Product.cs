namespace Citrus.Models
{
    /*
        Represents each product that a client can order
    */
    public class Product
    {
        public int ProductId { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; } = "/images/placeholder-img.png";

        public List<ProductAddon> ProductAddons { get; set; } = []; // Navigation property for the "ProductAddon" table

        public ProductCategory? ProductCategory { get; set; } // Navigation property for the "ProductCategory" table
        public int ProductCategoryId { get; set; } // foreign key with "ProductCategory" table

        public decimal Price { get; set; }
        public int? Stock { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}