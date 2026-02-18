using Clgproj.Model;

namespace Clgproj.Services.Interfaces
{
    public interface IFertilizerService
    {

        Task RecordUsageAsync(FertilizerUsage usage);
        Task<List<FertilizerUsage>> GetUsageHistoryAsync(int plantId);
        Task<List<FertilizerRecommendation>> GetRecommendationsAsync(int plantId);
        Task<FertilizerRecommendation> GetOptimalRecommendationAsync(int plantId);
        Task<List<FertilizerRecommendation>> GetRecommendationsByGrowthStageAsync(int plantId, string growthStage);
        Task<List<FertilizerRecommendation>> GetRecommendationsByPlantTypeAsync(string plantType);
        Task<List<FertilizerRecommendation>> GetRecommendationsByPlantTypeAndGrowthStageAsync(string plantType, string growthStage);

    }
}

