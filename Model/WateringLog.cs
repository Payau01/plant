namespace Clgproj.Model
{
    public class WateringLog
    {
        public int Id { get; set; }
        public int PlantId { get; set; }

        public decimal WaterUsedInLiters { get; set; }
        public DateTime WateredAt { get; set; }
        public bool IsAutomatic { get; set; }

    }
}
