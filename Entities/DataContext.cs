using Microsoft.EntityFrameworkCore;

namespace PizzeriaManagementAPI.Entities
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Dish> Dishes { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<CustomerData> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderItem>()
                .HasOne(oi => oi.Order)
                .WithMany(o => o.OrderItems)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Order>()
                .HasOne(o => o.CustomerData)
                .WithOne(c => c.Order)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }

    }
}
