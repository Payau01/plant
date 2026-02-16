using Clgproj.Repository.Interfaces;
using Clgproj.Services.Interfaces;

namespace Clgproj.Services.Implemantations
{
    public class EligibilityService : IEligibilityService
    {
        private readonly IFarmerProfileRepository _farmerRepo;
        private readonly IGovernmentSchemeRepository _schemeRepo;

        public EligibilityService(
            IFarmerProfileRepository farmerRepo,
            IGovernmentSchemeRepository schemeRepo)
        {
            _farmerRepo = farmerRepo;
            _schemeRepo = schemeRepo;
        }

        public async Task<(bool IsEligible, string Reason)>
            ValidateAsync(int farmerId, int schemeId)
        {
            var farmer = await _farmerRepo.GetByIdAsync(farmerId);
            var scheme = await _schemeRepo.GetByIdAsync(schemeId);

            if (farmer == null)
                return (false, "Farmer profile not found");

            if (scheme == null || !scheme.IsActive)
                return (false, "Scheme is not active");

            if (!string.Equals(farmer.State, scheme.State,
                StringComparison.OrdinalIgnoreCase))
                return (false, "Scheme not applicable in farmer state");

            if (farmer.LandSizeInAcres > scheme.MaxLandSizeAllowed)
                return (false, "Land size exceeds scheme limit");

            if (!string.Equals(farmer.CropGrown, scheme.ApplicableCrop,
                StringComparison.OrdinalIgnoreCase))
                return (false, "Crop not eligible");

            return (true, "Eligible");
        }
    }
}
