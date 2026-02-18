using Clgproj.Data;
using Clgproj.Model;
using Clgproj.Services.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace Clgproj.Services.Implemantations
{
    public class plantHistoryService :IPlantHistoryService
    {
        private readonly AppDbContext _context;

        public plantHistoryService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Plant> GetPlantWithHistoryAsync(int plantId)
        {
            // Implementation for fetching plant history
            return await _context.Plant
                .Include(p => p.History)
                .FirstOrDefaultAsync(p => p.Id == plantId);
        }
    }
}