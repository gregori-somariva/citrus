namespace Citrus.Models
{
    public class OrderItemAddon
    {
        public int OrderItemAddonId { get; set; }

        public int OrderItemId { get; set; }
        public OrderItem? OrderItem { get; set; }

        public int ProductAddonId { get; set; }
        public ProductAddon? ProductAddon { get; set; }

        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; } 
        public decimal TotalPrice { get; set; }
    }
}
