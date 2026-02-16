using Clgproj.Data;
using Clgproj.Model;
using Clgproj.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Clgproj.Repository.Implementations
{
 
public class FertilizerRepository : IFertilizerRepository
    {
        private readonly DbContext _context;

        public FertilizerRepository(DbContext context)
        {
            _context = context;
        }

        public async Task<FertilizerUsage> AddAsync(FertilizerUsage usage)
        {
            _context.Set<FertilizerUsage>().Add(usage);
            await _context.SaveChangesAsync();
            return usage;
        }

        public async Task<List<Fertilizer>> GetAvailableFertilizersAsync()
        {
            // Fix: Use _context.Set<Fertilizer>() instead of _context.Fertilizers
            return await _context.Set<Fertilizer>()
                .Where(f => f.StockInKg > 0 && f.ExpiryDate > DateTime.UtcNow)
                .ToListAsync();
        }

        public async Task<List<FertilizerUsage>> GetByPlantIdAsync(int plantId)
        {
            return await _context.Set<FertilizerUsage>()
                                 .Where(f => f.PlantId == plantId)
                                 .ToListAsync();
        }

        public async Task UpdateStockAsync(int fertilizerId, int usedKg)
        {
            // Fix: Use _context.Set<Fertilizer>() instead of _context.Fertilizer
            var fertilizer = await _context.Set<Fertilizer>().FindAsync(fertilizerId);
            if (fertilizer == null) return;

            fertilizer.StockInKg -= usedKg;
            await _context.SaveChangesAsync();
        }
    }
}


