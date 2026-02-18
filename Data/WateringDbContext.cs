using Clgproj.Model;
using Microsoft.EntityFrameworkCore;

namespace Clgproj.Data
{
    public class wateringServiceDbContext : DbContext
    {
        public DbSet<WateringSchedule> WateringSchedules
                => Set<WateringSchedule>();
        public DbSet<WateringLog> WateringLogs 
            => Set<WateringLog>();
    }
}
