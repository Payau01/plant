using Clgproj.Model;
using Microsoft.AspNetCore.Http;

namespace Clgproj.Services.Interfaces
{
    public interface IPlantAnalysisService
    {
        Task<PlantAnalysisResult> AnalyzePlantAsync(IFormFile plantImage);
    }
}
