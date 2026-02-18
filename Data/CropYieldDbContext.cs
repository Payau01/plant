using Clgproj.Model;
using Microsoft.EntityFrameworkCore;

namespace Clgproj.Data
{


        public class CropYieldDbContext : DbContext
        {
            public CropYieldDbContext(DbContextOptions<CropYieldDbContext> options)
                : base(options)
            {
            }

            public DbSet<CropYieldPridiction> CropYieldPredictions
                => Set<CropYieldPridiction>();
        }

    }

