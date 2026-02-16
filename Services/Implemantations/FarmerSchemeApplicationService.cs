using Clgproj.Model;
using Clgproj.Repository.Interfaces;
using Clgproj.Services.Interfaces;

namespace Clgproj.Services.Implemantations
{
    public class FarmerSchemeApplicationService : IFarmerSchemeApplicationService
    {
        private readonly IFarmerSchemeApplicationRepository _repository;

        public FarmerSchemeApplicationService(
            IFarmerSchemeApplicationRepository repository)
        {
            _repository = repository;
        }

        public async Task<FarmerSchemeApplication> ApplyAsync(
            int schemeId, int farmerId)
        {
            var application = new FarmerSchemeApplication
            {
                SchemeId = schemeId,
                FarmerId = farmerId,
                Status = "Pending"
            };

            return await _repository.ApplyAsync(application);
        }

        public async Task<List<FarmerSchemeApplication>> GetFarmerApplicationsAsync(
            int farmerId)
        {
            return await _repository.GetByFarmerIdAsync(farmerId);
        }

        public async Task ApproveAsync(int applicationId)
        {
            await _repository.UpdateStatusAsync(applicationId, "Approved");
        }

        public async Task RejectAsync(int applicationId)
        {
            await _repository.UpdateStatusAsync(applicationId, "Rejected");
        }
    }
    
}
