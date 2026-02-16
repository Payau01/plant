using Clgproj.Model;

namespace Clgproj.Services.Interfaces
{
    public interface IFertilizerRecommandationService
    {

        Task RecordUsageAsync(FertilizerUsage usage);
        Task<List<FertilizerUsage>> GetUsageHistoryAsync(int plantId);
        Task<object?> RecommendAsync(string plantType, string growthStage);
    }
}

