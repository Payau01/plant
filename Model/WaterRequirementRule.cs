namespace Clgproj.Model
{
    public class WaterRequirementRule
    {

        public int Id { get; set; }
        public string PlantType { get; set; } = string.Empty;
        public float BaseLitersPerDay { get; set; }
        public string Season { get; set; } = string.Empty; // Summer, Winter, Rainy
        public float AdjustmentFactor { get; set; } // e.g. 1.2, 0.8
    }
}
