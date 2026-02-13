namespace Clgproj.Model
{

    public class WateringSchedule
    {
        public int Id { get; set; }
        public int PlantId { get; set; }

        public WateringFrequency? Frequency { get; set; } // Daily / Weekly / Monthly
        public float LitersRequired { get; set; }

        public DateTime LastWateredOn { get; set; }
        public DateTime NextWateringOn { get; set; }
    }
}
