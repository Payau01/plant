using Clgproj.Model;

namespace Clgproj.Repository.Interfaces
{
    public interface IFarmerProfileRepository
    {
        Task<FarmerProfile?> GetByIdAsync(int farmerId);
    }
}
