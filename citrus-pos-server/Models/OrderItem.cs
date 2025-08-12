namespace Citrus.Models
{
    /*
        Represents each unique product inside an order that a client made
    */
    public class OrderItem
    {
        public int OrderItemId { get; set; }

        public Order? Order { get; set; } // Navigation property for the "Order" table
        public int OrderId { get; set; } // Foreign key with the "Order" table

        public Product? Product { get; set; } // Navigation property for the "Product" table
        public int ProductId { get; set; } // Foreign key with the "Product" table

        public List<ProductAddon> ProductAddons { get; set; } = [];

        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
