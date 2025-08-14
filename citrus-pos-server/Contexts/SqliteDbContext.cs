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
        public DbSet<OrderItemAddon> OrderItemAddons { get; set; }
        public DbSet<ProductAddon> ProductAddons { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Order → OrderItem (1-to-many)
            modelBuilder.Entity<Order>()
                .HasMany(o => o.OrderItems)
                .WithOne(oi => oi.Order)
                .HasForeignKey(oi => oi.OrderId);

            // OrderItem → OrderItemAddon (1-to-many)
            modelBuilder.Entity<OrderItem>()
                .HasMany(oi => oi.Addons)
                .WithOne(a => a.OrderItem)
                .HasForeignKey(a => a.OrderItemId);

            // OrderItemAddon → ProductAddon (many-to-1)
            modelBuilder.Entity<OrderItemAddon>()
                .HasOne(a => a.ProductAddon)
                .WithMany()
                .HasForeignKey(a => a.ProductAddonId);

            base.OnModelCreating(modelBuilder);
        }

    }
}