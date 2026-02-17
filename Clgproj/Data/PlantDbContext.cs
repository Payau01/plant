using Clgproj.Model;
using Microsoft.EntityFrameworkCore;

namespace Clgproj.Data
{
    public class PlantDbContext : DbContext
    {
        // Constructor to initialize DbContext with options
        public PlantDbContext(DbContextOptions<PlantServiceDbContext> options)
            : base(options) { }


        // Ensure there is no duplicate constructor with the same parameter types
        // If another constructor exists, remove or modify it to avoid CS0111

        public DbSet<Plant> Plants
            => Set<Plant>();

        public DbSet<PlantGrowthRecord> PlantGrowthRecords
            => Set<PlantGrowthRecord>();

        public DbSet<PlantHistory> PlantHistories
            => Set<PlantHistory>();
    }
    
}

