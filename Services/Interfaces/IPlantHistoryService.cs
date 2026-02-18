using Clgproj.Model;

namespace Clgproj.Services.Interfaces
{
    public interface IplantHistoryService
    {
        Task<object> GetPlantWithHistoryAsync(int plantId);
    }
}
