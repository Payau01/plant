namespace Clgproj.Services.Implemantations
{
    public class WaterRequirementRule : IWaterRequirementRule
    {
        private readonly List<WaterRequirementRule> _rules =
        [
            new() { PlantType = "Tomato", Season = "Summer", RequiredLiters = 2.5f },
        new() { PlantType = "Tomato", Season = "Winter", RequiredLiters = 1.5f }
        ];

        public Task<WaterRequirementRule?> GetRuleAsync(string plantType, string season)
        {
            var rule = _rules.FirstOrDefault(r =>
                r.PlantType == plantType &&
                r.Season == season);

            return Task.FromResult(rule);
        }
    }
}