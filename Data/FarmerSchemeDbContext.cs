using Clgproj.Model;
using Microsoft.EntityFrameworkCore;

namespace Clgproj.Data
{
    public class FarmerSchemeDbContext : DbContext
    {
        public FarmerSchemeDbContext(
            DbContextOptions<FarmerSchemeDbContext> options)
            : base(options)
        {
        }

        public DbSet<FarmerSchemeApplication> FarmerSchemeApplications
            => Set<FarmerSchemeApplication>();
    }
}
