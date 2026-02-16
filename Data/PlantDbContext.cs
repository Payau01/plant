using Clgproj.Model;
using Microsoft.EntityFrameworkCore;

namespace Clgproj.Data
{
    public class PlantServiceDbContext : DbContext
    {
        // Fix for CS0246: Correct the type name to match the class name
        public PlantServiceDbContext(DbContextOptions<PlantServiceDbContext> options)
            : base(options) { }

        public DbSet<Plant> Plants 
            => Set<Plant>();

        public DbSet<PlantGrowthRecord> PlantGrowthRecords 
            => Set<PlantGrowthRecord>();

        public DbSet<PlantHistory> PlantHistories 
            => Set<PlantHistory>();
    }

}

