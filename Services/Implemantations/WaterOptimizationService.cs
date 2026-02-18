using Clgproj.Data;
using Clgproj.Model;
using Clgproj.Services.Interfaces;
using Microsoft.EntityFrameworkCore;



namespace Clgproj.Services.Implemantations
{
    public class waterOptimizationService : IWaterOptimizationService
    {
        private readonly IWaterRequirementRule _ruleService;
        private readonly AppDbContext _context;

        public waterOptimizationService(IWaterRequirementRule ruleService)
        {
            AppDbContext context,
           _ruleService = ruleService)
            {
                _context = context,
                _ruleService = ruleService;

            }
        }
        public async Task<decimal> CalculateRequiredWaterAsync(int plantId)
        {
            // Explicitly specify the DbSet to resolve ambiguity
            var plant = await _context.Set<Plant>().FindAsync(plantId);
            if (plant == null)
                throw new Exception("Plant not found");

            var season = CurrentSeason;

            var rule = await _context.WaterRequirementRules
                .FirstOrDefaultAsync(r =>
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

        Task<float> IWaterOptimizationService.CalculateRequiredWaterAsync(int plantId)
        {
            throw new NotImplementedException();
        }

        private string CurrentSeason
        {
            get
            {
                var month = DateTime.UtcNow.Month;

                if (month >= 3 && month <= 6) return "Summer";
                if (month >= 7 && month <= 9) return "Rainy";
                return "Winter";
            }
        }
    }
}

