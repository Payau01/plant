namespace Clgproj.Model
{
    public class waterRequirementRule
    {

        public int Id { get; set; }
        public string PlantType { get; set; } = string.Empty;
        public decimal BaseLitersPerDay { get; set; }
        public string Season { get; set; } = string.Empty; // Summer, Winter, Rainy
        public decimal AdjustmentFactor { get; set; } // e.g. 1.2, 0.8
    }
}
