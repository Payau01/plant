namespace Clgproj.Services.Interfaces
{
    public interface IDashboardService
    {
        Task<int> TotalPlantsAsync();
        Task<int> TotalAnalysesAsync();
    }
}
