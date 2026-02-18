using Clgproj.Model;

namespace Clgproj.Services.Interfaces
{
    public interface IwaterRequirementRule
    {
        Task<WaterRequirementRule?> GetRuleAsync(string plantType, string season);

    }
}
