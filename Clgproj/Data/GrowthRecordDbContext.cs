using Clgproj.Model;
using Microsoft.EntityFrameworkCore;


namespace Clgproj.Clgproj.Data
{
    public class GrowthDbContext : DbContext
    {
        public GrowthDbContext(DbContextOptions<GrowthDbContext> options)
            : base(options) { }

        public DbSet<PlantGrowthRecord> PlantGrowthRecords { get; set; }
    }
}
