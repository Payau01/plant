using Clgproj.Services.Interfaces;

namespace Clgproj.Services.Implemantations
{
    public class WaterRequirementRule : IWaterRequirementRule
    {
        private readonly List<WaterRequirementRule> _rules =
        [
            new() { PlantType = "Tomato", Season = "Summer", RequiredLiters = 2.5f },
        new() { PlantType = "Tomato", Season = "Winter", RequiredLiters = 1.5f }
        ];

        public string? PlantType { get;  set; }
        public string? Season { get; set; }
        public float RequiredLiters { get;  set; }

        public Task<WaterRequirementRule?> GetRuleAsync(string plantType, string season)
        {
            var rule = _rules.FirstOrDefault(r =>
                r.PlantType == plantType &&
                r.Season == season);

            return Task.FromResult(rule);
        }

        Task<Model.WaterRequirementRule?> IWaterRequirementRule.GetRuleAsync(string plantType, string season)
        {
            throw new NotImplementedException();
        }
    }
}