namespace Clgproj.Model
{
    public class PlantGrowthRecord
    {

        public int Id { get; set; }
        public int PlantId { get; set; }

        // Growth metrics
        public float HeightInCm { get; set; }
        public int LeafCount { get; set; }
        public int HealthScore { get; set; } // 0–100

        // Correlation metadata
        public DateTime RecordedOn { get; set; }

        // Optional links (future analytics)
        public int? WateringLogId { get; set; }
        public int? PlantAnalysisResultId { get; set; }
    }
}

