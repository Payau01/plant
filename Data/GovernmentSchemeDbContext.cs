using Clgproj.Model;
using Microsoft.EntityFrameworkCore;

namespace Clgproj.Data
{
    public class GovernmentSchemeDbContext : DbContext
    {
        public GovernmentSchemeDbContext(
            DbContextOptions<GovernmentSchemeDbContext> options)
            : base(options)
        {
        }

        public DbSet<GovernmentScheme> GovernmentSchemes
            => Set<GovernmentScheme>();
    }
}
