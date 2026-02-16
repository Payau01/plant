using Clgproj.Model;
using Microsoft.EntityFrameworkCore;

namespace Clgproj.Data
{
    public class FertilizerDbContext : DbContext
    {
        public DbSet<FertilizerUsage> FertilizerUsages { get; set; }
    }
}