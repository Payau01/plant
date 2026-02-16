using Clgproj.Model;

namespace Clgproj.Repository.Interfaces
{
    public interface ICropYieldRepository
    {
        Task<CropYieldPridiction> AddPredictionAsync(CropYieldPridiction prediction);
        Task<List<CropYieldPridiction>> GetByPlantIdAsync(int plantId);
    }
}
