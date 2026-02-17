using System.Net;

namespace Clgproj.Services.Interfaces
{
    public interface IwaterOptimizationService
    {
        Task<float> CalculateRequiredWaterAsync(int plantId);
    }
}
