using Clgproj.Data;
using Clgproj.Model;
using System.Linq;
using Clgproj.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Clgproj.Repository.Implementations
{
    public class plantGrowthRepository : IPlantGrowthRepository
    {
        private readonly AppDbContext _context;

        public plantGrowthRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(PlantGrowthRecord record)
        {
            _context.PlantGrowthRecords.Add(record);
            await _context.SaveChangesAsync();
        }

        public async Task<List<PlantGrowthRecord>> GetByPlantIdAsync(int plantId)
        {
            return await _context.PlantGrowthRecords
                .Where(r => r.PlantId == plantId)
                .OrderBy(r => r.RecordedOn)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}

