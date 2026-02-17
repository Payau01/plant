using Clgproj.Model;
using Clgproj.Repository.Implementations;
using Clgproj.Repository.Interfaces;
using Clgproj.Services.Interfaces;

namespace Clgproj.Services.Implemantations
{
    public class PlantGrowthService : IPlantGrowthService
    {
        private readonly IPlantGrowthRepository _repository;

        
        public async Task AddGrowthRecordAsync(PlantGrowthRecord record)
        {
            // Basic domain validation
            if (record.HealthScore < 0 || record.HealthScore > 100)
                throw new ArgumentException("Health score must be between 0 and 100.");

            record.RecordedOn = DateTime.UtcNow;

            object value = _repository.Add(record);
            await _repository.AddAsync(record);   // ✅ FIXED
        }

        public async Task<List<PlantGrowthRecord>> GetGrowthHistoryAsync(int plantId) => _repository.GetByPlantIdAsync(plantId);
    }

} /////

