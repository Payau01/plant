using Clgproj.Model;

namespace Clgproj.Services.Interfaces
{
    public interface IGovernmentSchemeService
    {
        Task<GovernmentScheme> CreateAsync(GovernmentScheme scheme);
        Task<List<GovernmentScheme>> GetActiveSchemesAsync();
        Task<List<GovernmentScheme>> RecommendAsync(string crop, string season);
        Task<GovernmentScheme?> GetByIdAsync(int id);
    }
}
