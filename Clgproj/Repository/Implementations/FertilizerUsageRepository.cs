using Clgproj.Model;
using Clgproj.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Clgproj.Repository.Implementations
{
 
    public class FertilizerUsageRepository : IFertilizerUsageRepository
    {
        private readonly DbContext _context;

        public FertilizerUsageRepository(DbContext context)
        {
            _context = context;
        }

        public async Task<FertilizerUsage> AddAsync(FertilizerUsage usage)
        {
            _context.Set<FertilizerUsage>().Add(usage);
            await _context.SaveChangesAsync();
            return usage;
        }

        public async Task<List<FertilizerUsage>> GetByPlantIdAsync(int plantId)
        {
            return await _context.Set<FertilizerUsage>()
                                 .Where(f => f.PlantId == plantId)
                                 .ToListAsync();
        }
    }
}
           