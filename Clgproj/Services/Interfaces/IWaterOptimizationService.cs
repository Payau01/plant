using System.Net;

namespace Clgproj.Services.Interfaces
{
    public interface IWaterOptimizationService
    {
        Task<decimal> CalculateRequiredWaterAsync(int plantId);
    }
}
