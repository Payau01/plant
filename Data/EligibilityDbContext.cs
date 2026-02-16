using Clgproj.Model;
using Microsoft.EntityFrameworkCore;

namespace Clgproj.Data
{
    public class EligibilityDbContext : DbContext
    {
        public EligibilityDbContext(
            DbContextOptions<EligibilityDbContext> options)
            : base(options)
        {
        }

        public DbSet<FarmerProfile> FarmerProfiles
            => Set<FarmerProfile>();
    }
    
}

