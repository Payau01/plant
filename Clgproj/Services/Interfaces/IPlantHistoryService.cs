using Clgproj.Model;

namespace Clgproj.Services.Interfaces
{
    public interface IPlantHistoryService
    {
        Task<Plant> GetPlantWithHistoryAsync(int plantId);
    }
}
