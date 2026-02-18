namespace Clgproj.Services.Interfaces
{
    public interface IDashboardService
    {
        Task<int> TotalPlantsAsync();
        Task<int> TotalAnalysesAsync();
        Task<int> TotalWaterUsedAsync();
        Task<int> TotalGrowthRecordsAsync();
        Task<int> TotalLegsAsync();
        Task<int> TotalLegsTotalAsync();

    }
}
