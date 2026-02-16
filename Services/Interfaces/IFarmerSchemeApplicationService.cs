using Clgproj.Model;

namespace Clgproj.Services.Interfaces
{
    public interface IFarmerSchemeApplicationService
    {
        Task<FarmerSchemeApplication> ApplyAsync(int schemeId, int farmerId);
        Task<List<FarmerSchemeApplication>> GetFarmerApplicationsAsync(int farmerId);
        Task ApproveAsync(int applicationId);
        Task RejectAsync(int applicationId);
    }
}
