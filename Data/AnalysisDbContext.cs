using Clgproj.Model;
using Microsoft.EntityFrameworkCore;

namespace Clgproj.Data
{
    public class WateringDbContext : DbContext
    {
        public WateringDbContext(DbContextOptions<WateringDbContext> options)
            : base(options) { }

        public DbSet<PlantAnalysisResult> PlantAnalysisResults
            => Set<PlantAnalysisResult>();
    }
}
