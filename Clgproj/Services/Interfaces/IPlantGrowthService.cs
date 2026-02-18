using Clgproj.Model;

namespace Clgproj.Services.Interfaces
{
    public interface IplantGrowthService
    {
        Task AddGrowthRecordAsync(PlantGrowthRecord record);
        Task<List<PlantGrowthRecord>> GetGrowthHistoryAsync(int plantId);

    }
}
