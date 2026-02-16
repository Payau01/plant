using Clgproj.Model;

namespace Clgproj.Services.Interfaces
{
    public interface ICropYieldService
    {
        Task<CropYieldPridiction> GeneratePridictionAsync(int plantId);
        Task<List<CropYieldPridiction>> GetPridictionHistoryAsync(int plantId);
    }
}
