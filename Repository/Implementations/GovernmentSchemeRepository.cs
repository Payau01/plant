using Clgproj.Data;
using Clgproj.Model;
using Clgproj.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Clgproj.Repository.Implementations
{
    public class GovernmentSchemeRepository : IGovernmentSchemeRepository 
    {
        private readonly GovernmentSchemeDbContext _context;

        public GovernmentSchemeRepository(GovernmentSchemeDbContext context)
        {
            _context = context;
        }

        public async Task<GovernmentScheme> AddAsync(GovernmentScheme scheme)
        {
            _context.GovernmentSchemes.Add(scheme);
            await _context.SaveChangesAsync();
            return scheme;
        }

        public async Task<List<GovernmentScheme>> GetAllAsync()
        {
            return await _context.GovernmentSchemes.ToListAsync();
        }

        public async Task<List<GovernmentScheme>> GetActiveAsync()
        {
            return await _context.GovernmentSchemes
                .Where(s => s.IsActive && s.EndDate >= DateTime.UtcNow)
                .ToListAsync();
        }

        public async Task<List<GovernmentScheme>> GetByCropAndSeasonAsync(
            string crop, string season)
        {
            return await _context.GovernmentSchemes
                .Where(s =>
                    s.ApplicableCrop == crop &&
                    s.Season == season &&
                    s.IsActive)
                .ToListAsync();
        }

        public async Task<GovernmentScheme?> GetByIdAsync(int id)
        {
            return await _context.GovernmentSchemes.FindAsync(id);
        }
    }
}
