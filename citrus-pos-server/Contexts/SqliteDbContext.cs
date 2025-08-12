using Microsoft.EntityFrameworkCore;

using Citrus.Models;

namespace Citrus.Contexts
{
    public class SqliteDbContext : DbContext
    {

        public SqliteDbContext(DbContextOptions<SqliteDbContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<ProductAddon> ProductAddons { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
    }
}