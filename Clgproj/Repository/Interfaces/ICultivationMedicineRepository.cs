using Clgproj.Model;

namespace Clgproj.Repository.Interfaces
{
    public interface ICultivationMedicineRepository
    {
        Task<CultivationMedicine> AddAsync(CultivationMedicine medicine);
        Task<CultivationMedicine?> GetByIdAsync(int id);
        Task<IEnumerable<CultivationMedicine>> GetAllAsync();
        Task<bool> UpdateAsync(CultivationMedicine medicine);
        Task<bool> DeleteAsync(int id);
    }

}