using Clgproj.Model;

namespace Clgproj.Repository.Interfaces
{
    public interface IGovernmentSchemeRepository
    {
        Task<GovernmentScheme> AddAsync(GovernmentScheme scheme);
        Task<List<GovernmentScheme>> GetAllAsync();
        Task<List<GovernmentScheme>> GetActiveAsync();
        Task<List<GovernmentScheme>> GetByCropAndSeasonAsync(string crop, string season);
        Task<GovernmentScheme?> GetByIdAsync(int id);
    }
}
