namespace Clgproj.Events
{
    public class PlantWateredEvent
    {
        public int PlantId { get; }
        public decimal WaterUsedInLiters { get; }
        public DateTime WateredAt { get; }

        public PlantWateredEvent(int plantId, decimal waterUsedInLiters)
        {
            PlantId = plantId;
            WaterUsedInLiters = waterUsedInLiters;
            WateredAt = DateTime.UtcNow;
        }
    }
}
