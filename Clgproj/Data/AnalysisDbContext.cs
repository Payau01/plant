using Clgproj.Model;
using Microsoft.EntityFrameworkCore;

namespace Clgproj.Data
{
    public class AnalysisDbContext : DbContext
    {
        public AnalysisDbContext(DbContextOptions<AnalysisDbContext> options)
            : base(options) { }

        public DbSet<PlantAnalysisResult> PlantAnalysisResults
            => Set<PlantAnalysisResult>();
    }
}
