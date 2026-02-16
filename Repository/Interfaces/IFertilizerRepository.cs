using Clgproj.Model;

namespace Clgproj.Repository.Interfaces
{
    public interface IFertilizerRepository
    {

        Task<FertilizerUsage> AddAsync(FertilizerUsage usage);
        Task<List<FertilizerUsage>> GetByPlantIdAsync(int plantId);
        Task<List<Fertilizer>> GetAvailableFertilizersAsync();
        Task UpdateStockAsync(int fertilizerId, int usedKg);
    }
}
