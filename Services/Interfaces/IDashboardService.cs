using Clgproj.Data;
using Clgproj.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Clgproj.Model;


namespace Clgproj.Services.Interfaces
{
    public class DashboardService : IDashboardService
    {
        private readonly AppDbContext _context;

        public DashboardService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<int> TotalPlantsAsync()
        {
            // Explicitly specify the DbSet to resolve ambiguity
            return await _context.Set<Plant>().CountAsync();
        }

        public async Task<int> TotalAnalysesAsync()
        {
            // Explicitly specify the DbSet to resolve ambiguity
            return await _context.Set<PlantGrowthRecord>().CountAsync();
        }
    }
}