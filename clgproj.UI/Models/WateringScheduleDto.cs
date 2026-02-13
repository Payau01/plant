namespace clgproj.UI.Models
{
    public class WateringScheduleDto
    {
        public int PlantId { get; set; }
        public int FrequencyInDays { get; set; }
        public DateTime NextWateringDate { get; set; }
    }
}
