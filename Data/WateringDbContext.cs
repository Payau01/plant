using Clgproj.Model;
using Microsoft.EntityFrameworkCore;

namespace Clgproj.Data
{
    public class WateringServiceDbContext : DbContext
    {
        public DbSet<WateringSchedule> WateringSchedules
                => Set<WateringSchedule>();
        public DbSet<WateringLog> WateringLogs 
            => Set<WateringLog>();
    }
}
