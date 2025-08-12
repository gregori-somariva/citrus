namespace Citrus.Models.Dtos
{
    public class ClientDto
    {
        public int ClientId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Location { get; set; }
        public string? IpAddress { get; set; }
        public string? Status { get; set; }
        public DateTime LastActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
