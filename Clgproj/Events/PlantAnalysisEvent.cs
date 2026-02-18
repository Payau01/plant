namespace Clgproj.Events
{
    public class plantAnalysisEvent
    {
        public int PlantId { get; }
        public string HealthStatus { get; }
        public decimal Confidence { get; }
        public DateTime AnalyzedOn { get; }

        public plantAnalysisEvent(int plantId, string healthStatus, decimal confidence)
        {
            PlantId = plantId;
            HealthStatus = healthStatus;
            Confidence = confidence;
            AnalyzedOn = DateTime.UtcNow;
        }
    }
}