using System.Collections.Generic;
using DistributorAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace DistributorAPI.Data
{
    public class DistributorContext : DbContext
    {
        public DistributorContext(DbContextOptions<DistributorContext> options) : base(options) { }

        public DbSet<DistributorStock> DistributorStocks { get; set; }
    }
}
