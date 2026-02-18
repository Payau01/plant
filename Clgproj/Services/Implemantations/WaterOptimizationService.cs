using Clgproj.Data;
using Clgproj.Model;
using Clgproj.Services.Interfaces;
using Microsoft.EntityFrameworkCore;



namespace Clgproj.Services.Implemantations
{
    public class WaterOptimizationService : IWaterOptimizationService
    {
        private readonly AppDbContext _context;

        public WaterOptimizationService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<float> CalculateRequiredWaterAsync(int plantId)
        {
            // Explicitly specify the DbSet to resolve ambiguity
            var plant = await _context.Set<Plant>().FindAsync(plantId);
            if (plant == null)
                throw new Exception("Plant not found");

            var season = GetCurrentSeason;

            var rule = await _context.WaterRequirementRules
                .FirstOrDefault(r =>
                    r.PlantType == plant.Species &&
                    r.Season == season);

            if (rule == null)
                return 0;

            // ✅ CORE SMART LOGIC
            var requiredWater = rule.BaseLitersPerDay * rule.AdjustmentFactor;

            return MathF.Round(requiredWater, 2);
        }

        public Task<object> CalculateRequiredWaterAsync(int plantId, object weatherData)
        {
            throw new NotImplementedException();
        }

        Task IWaterOptimizationService.CalculateRequiredWaterAsync(int plantId)
        {
            return CalculateRequiredWaterAsync(plantId);
        }

        Task<decimal> IWaterOptimizationService.CalculateRequiredWaterAsync(int plantId)
        {
            throw new NotImplementedException();
        }

        private string GetCurrentSeason()
        {
            var month = DateTime.UtcNow.Month;

            if (month >= 3 && month <= 6) return "Summer";
            if (month >= 7 && month <= 9) return "Rainy";
            return "Winter";
        }
    }
}
