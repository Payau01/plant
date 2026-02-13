using Clgproj.Model;
using Clgproj.Repository.Interfaces;
using Clgproj.Services.Interfaces;

namespace Clgproj.Services.Implemantations
{
    public class FertilizerService : IFertilizerService
    {
        private readonly IFertilizerUsageRepository _repository;

        public FertilizerService(IFertilizerUsageRepository repository)
        {
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
    }
}
