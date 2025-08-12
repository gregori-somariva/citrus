namespace Citrus.Models
{
    /*
        Represents a unique order made from a client
    */
    public class Order
    {
        public int OrderId { get; set; }

        public Client? Client { get; set; } // Navigation property for the "Client" table
        public int ClientId { get; set; } // Foreign key with the "Client" table

        public List<OrderItem> OrderItems { get; set; } = []; // Navigation property for the "OrderItem" table
        
        public decimal TotalAmount { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}