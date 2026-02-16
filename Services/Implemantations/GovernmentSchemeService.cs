using Clgproj.Model;
using Clgproj.Repository.Interfaces;
using Clgproj.Services.Interfaces;

namespace Clgproj.Services.Implemantations
{
    public class GovernmentSchemeService : IGovernmentSchemeService
    {
        private readonly IGovernmentSchemeRepository _repository;

        public GovernmentSchemeService(
            IGovernmentSchemeRepository repository)
        {
            _repository = repository;
        }

        public async Task<GovernmentScheme> CreateAsync(GovernmentScheme scheme)
        {
            scheme.IsActive = scheme.StartDate <= DateTime.UtcNow &&
                              scheme.EndDate >= DateTime.UtcNow;

            return await _repository.AddAsync(scheme);
        }

        public async Task<List<GovernmentScheme>> GetActiveSchemesAsync()
        {
            return await _repository.GetActiveAsync();
        }

        public async Task<List<GovernmentScheme>> RecommendAsync(
            string crop, string season)
        {
            return await _repository.GetByCropAndSeasonAsync(crop, season);
        }

        public async Task<GovernmentScheme?> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }
    }
}
