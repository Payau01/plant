using Clgproj.Model;

namespace Clgproj.Services.Interfaces
{
    public interface IWaterRequirementRule
    {
        Task<WaterRequirementRule?> GetRuleAsync(string plantType, string season);
    }
}
