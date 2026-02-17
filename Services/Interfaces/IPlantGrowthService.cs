using Clgproj.Model;

namespace Clgproj.Services.Interfaces

{
    public interface IPlantGrowthService
    {
        Task AddGrowthRecordAsync(PlantGrowthRecord record);
        Task<List<PlantGrowthRecord>> GetGrowthHistoryAsync(int plantId);
    }

    public interface IPlantGrowthService
    {
        Task AddGrowthRecordAsync(PlantGrowthRecord record);
        Task<List<PlantGrowthRecord>> GetGrowthHistoryAsync(int plantId);

    }
}
//
