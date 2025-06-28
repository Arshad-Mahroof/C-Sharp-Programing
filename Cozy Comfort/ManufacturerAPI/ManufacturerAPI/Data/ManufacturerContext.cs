using ManufacturerAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ManufacturerAPI.Data
{
    public class ManufacturerContext : DbContext
    {
        public ManufacturerContext(DbContextOptions<ManufacturerContext> options) : base(options) { }

        public DbSet<Blanket> Blankets { get; set; }
    }
}
