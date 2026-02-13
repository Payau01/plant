namespace Clgproj.Events
{
    public class PlantAnalysisEvent
    {
        public int PlantId { get; }
        public string HealthStatus { get; }
        public float Confidence { get; }
        public DateTime AnalyzedOn { get; }

        public PlantAnalysisEvent(int plantId, string healthStatus, float confidence)
        {
            PlantId = plantId;
            HealthStatus = healthStatus;
            Confidence = confidence;
            AnalyzedOn = DateTime.UtcNow;
        }
    }
}