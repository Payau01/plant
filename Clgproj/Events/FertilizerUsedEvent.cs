namespace Clgproj.Events
{
    public class fertilizerUsedEvent
    {
        public int PlantId { get; }
        public string FertilizerName { get; }
        public float QuantityInGrams { get; }
        public DateTime AppliedOn { get; }

        public fertilizerUsedEvent(int plantId, string fertilizerName, float quantity)
        {
            PlantId = plantId;
            FertilizerName = fertilizerName;
            QuantityInGrams = quantity;
            AppliedOn = DateTime.UtcNow;
        }
    }
}