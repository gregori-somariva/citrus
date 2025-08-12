namespace Citrus.Models
{
    /*
        Represents each unique terminal for the POS system
    */
    public class Client
    {
        public int ClientId { get; set; }
        public required string Name { get; set; }
        public string? Location { get; set; }
        public string? IPAddress { get; set; }
        public DateTime LastActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool IsActive { get; set; } = true;
    }
}