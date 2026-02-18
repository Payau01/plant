using Clgproj.Model;
using Microsoft.EntityFrameworkCore;

namespace Clgproj.Data
{
    public class fertilizerDbContext : DbContext
    {
        public DbSet<FertilizerUsage> FertilizerUsages { get; set; }
    }
}