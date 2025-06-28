using Microsoft.EntityFrameworkCore;
using SellerAPI.Models;

namespace SellerAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<SellerStock> SellerStocks { get; set; }
        public DbSet<CustomerOrder> CustomerOrders { get; set; }
    }
}
