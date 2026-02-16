using Clgproj.Data;
using Clgproj.Model;
using Clgproj.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Clgproj.Repository.Implementations
{
    public class FarmerSchemeApplicationRepository
       : IFarmerSchemeApplicationRepository
    {
        private readonly FarmerSchemeDbContext _context;

        public FarmerSchemeApplicationRepository(
            FarmerSchemeDbContext context)
        {
            _context = context;
        }

        public async Task<FarmerSchemeApplication> ApplyAsync(
            FarmerSchemeApplication application)
        {
            _context.FarmerSchemeApplications.Add(application);
            await _context.SaveChangesAsync();
            return application;
        }

        public async Task<List<FarmerSchemeApplication>> GetByFarmerIdAsync(
            int farmerId)
        {
            return await _context.FarmerSchemeApplications
                .Where(a => a.FarmerId == farmerId)
                .ToListAsync();
        }

        public async Task<FarmerSchemeApplication?> GetByIdAsync(int id)
        {
            return await _context.FarmerSchemeApplications.FindAsync(id);
        }

        public async Task UpdateStatusAsync(int applicationId, string status)
        {
            var application = await _context.FarmerSchemeApplications
                .FindAsync(applicationId);

            if (application == null) return;

            application.Status = status;
            await _context.SaveChangesAsync();
        }
    }
}