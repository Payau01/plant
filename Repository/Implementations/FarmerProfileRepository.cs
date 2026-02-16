using Clgproj.Data;
using Clgproj.Model;
using Clgproj.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Clgproj.Repository.Implementations
{
    public class FarmerProfileRepository : IFarmerProfileRepository
    {
        private readonly EligibilityDbContext _context;

        public  FarmerProfileRepository(
            EligibilityDbContext context)
        {
            _context = context;
        }

        public async Task<FarmerProfile?> GetByIdAsync(int farmerId)
        {
            return await _context.FarmerProfiles
                .FirstOrDefaultAsync(f => f.Id == farmerId);
        }
    }
}
