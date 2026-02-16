using Clgproj.Model;

namespace Clgproj.Repository.Interfaces
{
    public interface IFarmerSchemeApplicationRepository
    {
        Task<FarmerSchemeApplication> ApplyAsync(FarmerSchemeApplication application);
        Task<List<FarmerSchemeApplication>> GetByFarmerIdAsync(int farmerId);
        Task<FarmerSchemeApplication?> GetByIdAsync(int id);
        Task UpdateStatusAsync(int applicationId, string status);
    }
}

