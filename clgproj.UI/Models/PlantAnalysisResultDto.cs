namespace clgproj.UI.Models
{
    public class PlantAnalysisResultDto
    {
        public string? HealthStatus { get; set; }
        public string? DetectedDisease { get; set; }
        public double ConfidenceScore { get; set; }
        public string? Recommendation { get; set; }
    }
}
