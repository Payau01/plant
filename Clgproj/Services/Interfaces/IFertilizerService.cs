using Clgproj.Model;

namespace Clgproj.Services.Interfaces
{
    public interface IFertilizerService
    {

        Task RecordUsageAsync(FertilizerUsage usage);
        Task<List<FertilizerUsage>> GetUsageHistoryAsync(int plantId);
    }
}

