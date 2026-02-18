using Clgproj.Model;
using Microsoft.AspNetCore.Http;

namespace Clgproj.Services.Interfaces
{
    public interface IplantAnalysisService
    {
        Task<PlantAnalysisResult> GetAnalysisResultAsync(int plantId);
        Task<IEnumerable<PlantAnalysisResult>> GetPlantHistoryAsync(int plantId);
        Task UpdatePlantHealthStatusAsync(int plantId, string healthStatus);
        Task UpdatePlantTypeAsync(int plantId, object plantType);
        Task UpdatePlantAnalysisResultAsync(PlantAnalysisResult result);
        Task DeletePlantAnalysisResultAsync(int plantId);
        Task<object> PlantAnalysisAsync(IFormFile image);
    }
}