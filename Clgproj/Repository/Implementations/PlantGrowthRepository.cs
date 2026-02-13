using Clgproj.Data;
using Clgproj.Model;
using Clgproj.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Clgproj.Repository.Implementations
{
    public class PlantGrowthRepository : IPlantGrowthRepository
    {
        private readonly AppDbContext _context;

        public PlantGrowthRepository(AppDbContext context)
        {
            _context = context;
        }

        public new async Task AddAsync(PlantGrowthRecord record)
        {
            _context.PlantGrowthRecords.Add(record);
            await _context.SaveChangesAsync();
        }

        public new async Task<List<PlantGrowthRecord>> GetByPlantIdAsync(int plantId)
        {
            return await _context.PlantGrowthRecords
                .Where(r => r.PlantId == plantId)
                .OrderBy(r => r.RecordedOn)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}

