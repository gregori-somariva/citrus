namespace Citrus.Models
{
    /*
        Represents the additionals that a client
        could add to a product. Ex: Extra cheese on a fries portion
    */
    public class ProductAddon
    {
        public int ProductAddonId { get; set; }

        public Product? Product { get; set; } // Navigation property for "Product" table
        public int ProductId { get; set; } // Foreign key to "Product" 
        
        public required string Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public string? ImageUrl { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public List<OrderItem> OrderItems { get; set; } = [];
    }
}