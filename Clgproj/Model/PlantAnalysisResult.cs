namespace Clgproj.Model
{
    public class plantAnalysisResult

    {
        public int Id { get; set; }
        public int PlantImageId { get; set; }
        public string? DiseaseName { get; set; }
        public float Confidence { get; set; }
        public string Recommendation { get; set; } = string.Empty;
        public string? HealthStatus { get; internal set; }
        public int PlantId { get; internal set; }
        public object? PlantType { get; internal set; }
    }
}

