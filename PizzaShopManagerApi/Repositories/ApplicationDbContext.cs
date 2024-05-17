using Microsoft.EntityFrameworkCore;

using PizzaShopManagerApi.Models;

namespace PizzaShopManagerApi.Repositories;

public class ApplicationDbContext : DbContext
{
    public DbSet<ModelBase> ModelBase { get; set; }

    public ApplicationDbContext(DbContextOptions options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ModelBase>().UseTpcMappingStrategy();
        modelBuilder.Entity<Pizza>().ToTable("Pizza");
        modelBuilder.Entity<Order>().ToTable("Order");
        modelBuilder.Entity<OrderItem>().ToTable("OrderItem");
        modelBuilder.Entity<Customer>().ToTable("Customer");
    }
}
