using System.Net;

namespace Clgproj.Services.Interfaces
{
    public interface IWaterOptimizationService
    {
        Task<float> CalculateRequiredWaterAsync(int plantId);
    }
}
