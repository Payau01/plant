using Clgproj.Model;
using Clgproj.Repository.Interfaces;
using Clgproj.Services.Implemantations;

namespace Clgproj.Repository.Interfaces
{
    public class IPlantGrowthRepository : IPlantGrowthRepositoryBase
    {
        internal object Add(PlantGrowthRecord record)
        {
            throw new NotImplementedException();
        }

        internal List<PlantGrowthRecord> GetByPlantId(int plantId)
        {
            throw new NotImplementedException();
        }
    }
}
