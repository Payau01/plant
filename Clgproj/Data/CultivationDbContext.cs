using Clgproj.Model;
using Microsoft.EntityFrameworkCore;

namespace Clgproj.Data
{
    public class CultivationDbContext : DbContext
    {
        public CultivationDbContext(DbContextOptions<CultivationDbContext> options)
            : base(options) { }

        public DbSet<Plant> Plants => Set<Plant>();
        public DbSet<PlantGrowthHistory> PlantGrowthHistories => Set<PlantGrowthHistory>();
        public DbSet<WateringSchedule> WateringSchedules => Set<WateringSchedule>();


        public DbSet<CultivationMedicine> CultivationMedicines
            => Set<CultivationMedicine>();

    }
}
