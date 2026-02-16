using Clgproj.Model;

namespace Clgproj.Repository.Interfaces
{
    public interface IFertilizerUsageRepository
    {

        Task<FertilizerUsage> AddAsync(FertilizerUsage usage);
        Task<List<FertilizerUsage>> GetByPlantIdAsync(int plantId);
    }
}
