using CQRSApp.Models;
using Microsoft.EntityFrameworkCore;

namespace CQRSApp.Context
{
    public class PostgreDbContext : DbContext
    {
        private readonly string _connectionStr = "User ID=postgres; Password=0102; Host=localhost; Port=5432; Database=CqrsDb; Pooling=false; Timeout=300; CommandTimeout=180;";

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Product> Products { get; set; }

        public PostgreDbContext()
        {

        }

        public PostgreDbContext(string connectionStr)
        {
            _connectionStr = connectionStr;
        }

        public PostgreDbContext(DbContextOptions<PostgreDbContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_connectionStr);
            base.OnConfiguring(optionsBuilder);
        }
    }
}
