namespace Clgproj.Model
{
    public class FertilizerRecommendationRule
    {

        public int Id { get; set; }
        public string PlantType { get; set; } = string.Empty;
        public string GrowthStage { get; set; } = string.Empty;

        public decimal RequiredNitrogen { get; set; }
        public decimal RequiredPhosphorus { get; set; }
        public decimal RequiredPotassium { get; set; }
    }
}
