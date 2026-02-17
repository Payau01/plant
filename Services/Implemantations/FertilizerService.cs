using Clgproj.Data;
using Clgproj.Model;
using Clgproj.Repository.Interfaces;
using Clgproj.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Clgproj.Services.Implemantations
{
    public class FertilizerRecommendationService : IFertilizerRecommandationService
    {
        private readonly FertilizerDbContext _context;
        private readonly IFertilizerRepository _repository;

        public FertilizerRecommendationService(
            FertilizerDbContext context,
            IFertilizerRepository repository)
        {
            _context = context;
            _repository = repository;
        }

        public async Task RecordUsageAsync(FertilizerUsage usage)
        {
            if (usage.QuantityKg <= 0)
                throw new ArgumentException("Quantity must be greater than zero.");

            usage.AppliedOn = DateTime.UtcNow;
            await _repository.AddAsync(usage);
        }

        public async Task<List<FertilizerUsage>> GetUsageHistoryAsync(int plantId)
        {
            return await _repository.GetByPlantIdAsync(plantId);
        }

        public async Task<Fertilizer?> RecommendAsync(string plantType, string growthStage)
        {
            var rule = await _context.FertilizerRules.FirstOrDefaultAsync(r =>
                r.PlantType == plantType &&
                r.GrowthStage == growthStage);

            if (rule == null) return null;

            var fertilizers = await _repository.GetAvailableFertilizersAsync();

            return fertilizers.FirstOrDefault(f =>
                f.Nitrogen >= rule.RequiredNitrogen &&
                f.Phosphorus >= rule.RequiredPhosphorus &&
                f.Potassium >= rule.RequiredPotassium);
        }

        Task<object?> IFertilizerRecommandationService.RecommendAsync(string plantType, string growthStage)
        {
            throw new NotImplementedException();
        }
    }

}
