using Clgproj.Model;
using Clgproj.Repository.Interfaces;
using Clgproj.Services.Interfaces;

namespace Clgproj.Services.Implemantations
{
    public class CropYieldService : ICropYieldService
    {
        private readonly ICropYieldRepository _repository;

        public CropYieldService(ICropYieldRepository repository)
        {
            _repository = repository;
        }

        public async Task<CropYieldPridiction> GeneratePredictionAsync(int plantId)
        {
            // 🔹 Simple rule-based logic

            decimal baseYield = 100m;
            decimal growthFactor = 1.2m;
            decimal fertilizerFactor = 1.1m;
            decimal waterFactor = 1.15m;

            decimal expectedYield =
                baseYield * growthFactor * fertilizerFactor * waterFactor;

            decimal confidence = 0.80m;

            var prediction = new CropYieldPridiction
            {
                PlantId = plantId,
                ExpectedYieldKg = expectedYield,
                Confidence = confidence,
                PredictedOn = DateTime.UtcNow
            };

            return await _repository.AddPredictionAsync(prediction);
        }

        public Task<CropYieldPridiction> GeneratePridictionAsync(int plantId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<CropYieldPridiction>> GetPredictionHistoryAsync(int plantId)
        {
            return await _repository.GetByPlantIdAsync(plantId);
        }

        public Task<List<CropYieldPridiction>> GetPridictionHistoryAsync(int plantId)
        {
            throw new NotImplementedException();
        }
    }
}
