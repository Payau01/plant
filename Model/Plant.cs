namespace Clgproj.Model
{
    public class Plant
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Species { get; set; }
        public object? Images { get; internal set; }

        // Fix for CS0246: Ensure the 'PlantGrowthHistory' type is defined and accessible.
        // Fix for CS8618: Initialize the collection to avoid null values.
       
        public object? History { get; internal set; }
        public object? FertilizerUsages { get; internal set; }
        public object? Location { get; internal set; }
        public object? WateringLogs { get; internal set; }
        public object? GrowthRecords { get; internal set; }

        public ICollection<WateringSchedule> WateringSchedules { get; set; } = new List<WateringSchedule>();
        public ICollection<PlantHistory> GrowthHistories { get; set; } = new List<PlantHistory>();
        public ICollection<FertilizerUsage> FertilizerUsagesCollection { get; set; } = new List<FertilizerUsage>();

        public ICollection<WateringLog> WateringLog { get; set; } = new List<WateringLog>();
        public ICollection<PlantGrowthRecord> GrowthRecord { get; set; } = new List<PlantGrowthRecord>();


    }
}

