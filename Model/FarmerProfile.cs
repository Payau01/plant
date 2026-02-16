namespace Clgproj.Model
{
    public class FarmerProfile
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string State { get; set; } = string.Empty;

        public decimal LandSizeInAcres { get; set; }

        public string CropGrown { get; set; } = string.Empty;
    }
}
