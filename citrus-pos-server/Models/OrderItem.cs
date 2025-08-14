namespace Citrus.Models
{
    /*
        Represents each unique product inside an order that a client made
    */
    public class OrderItem
    {
        public int OrderItemId { get; set; }

        public Order? Order { get; set; }
        public int OrderId { get; set; }

        public Product? Product { get; set; }
        public int ProductId { get; set; }

        public List<OrderItemAddon> Addons { get; set; } = [];

        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
    }

}
