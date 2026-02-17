namespace Clgproj.Model
{
 
    public class Plant
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string? Species { get; set; }

        public string? ImageUrl { get; set; }

        // Relationships

        public ICollection<WateringSchedule> WateringSchedules { get; set; }
            = new List<WateringSchedule>();

        public ICollection<PlantHistory> GrowthHistories { get; set; }
            = new List<PlantHistory>();

        public ICollection<FertilizerUsage> FertilizerUsages { get; set; }
            = new List<FertilizerUsage>();

        public ICollection<WateringLog> WateringLogs { get; set; }
            = new List<WateringLog>();

        public ICollection<PlantGrowthRecord> GrowthRecords { get; set; }
            = new List<PlantGrowthRecord>();
    }
}

