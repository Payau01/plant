namespace clgproj.UI.Models
{
    public class FertilizerUsageDto
    {
        public int PlantId { get; set; }
        public string? FertilizerName { get; set; }
        public double Quantity { get; set; }
        public DateTime UsedOn { get; set; } = DateTime.UtcNow;
    }
}
