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
        
    }
}
