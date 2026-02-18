using System.Net;

namespace Clgproj.Services.Interfaces
{
    public interface IWaterOptimizationService
    {
        
        Task<object> CalculateRequiredWaterAsync(int plantId, object weatherData);
        Task CalculateRequiredWaterAsync(int plantId);
    }
}
