namespace Clgproj.Model
{

    public class wateringSchedule
    {
        public int Id { get; set; }
        public int PlantId { get; set; }

        public WateringFrequency? Frequency { get; set; } // Daily / Weekly / Monthly
        public decimal LitersRequired { get; set; }

        public DateTime LastWateredOn { get; set; }
        public DateTime NextWateringOn { get; set; }
    }
}
