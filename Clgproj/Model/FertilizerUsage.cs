namespace Clgproj.Model
{
    public class FertilizerUsage
    {

        public int Id { get; set; }
        public int PlantId { get; set; }
        public string FertilizerName { get; set; } = string.Empty;
        public decimal QuantityKg { get; set; }
        public DateTime AppliedOn { get; set; }
        public string Notes { get; set; } = string.Empty;
        public decimal QuantityInGrams { get; internal set; }
    }
}

