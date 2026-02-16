namespace Clgproj.Model
{
    public class CropYieldPridiction
    {
        public int Id { get; set; }
        public int PlantId { get; set; }

        public decimal ExpectedYieldKg { get; set; }
        public decimal Confidence { get; set; }
        public DateTime PredictedOn { get; set; }
    }
}
