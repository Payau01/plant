using Clgproj.Data.Clgproj.Data;
using Clgproj.Model;
using Clgproj.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Clgproj.Repository.Implementations
{
    public class CropYieldRepository : ICropYieldRepository
    {
        private readonly CropYieldDbContext _context;

        public CropYieldRepository(CropYieldDbContext context)
        {
            _context = context;
        }

        public async Task<CropYieldPridiction> AddPredictionAsync(CropYieldPridiction prediction)
        {
            _context.CropYieldPredictions.Add(prediction);
            await _context.SaveChangesAsync();
            return prediction;
        }

        public async Task<List<CropYieldPridiction>> GetByPlantIdAsync(int plantId)
        {
            return await _context.CropYieldPredictions
                .Where(p => p.PlantId == plantId)
                .OrderByDescending(p => p.PredictedOn)
                .ToListAsync();
        }
    }
}
