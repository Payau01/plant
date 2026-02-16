using Clgproj.Data;
using Clgproj.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Clgproj.Data
{
    public class FertilizerDbContext : DbContext
    {
        public FertilizerDbContext(DbContextOptions<FertilizerDbContext> options)
            : base(options) { }

        public DbSet<Fertilizer> Fertilizer => Set<Fertilizer>();
        public DbSet<FertilizerRecommendationRule> FertilizerRules => Set<FertilizerRecommendationRule>();
    }
}
