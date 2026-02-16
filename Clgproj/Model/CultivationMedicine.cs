namespace Clgproj.Model
{
    public class CultivationMedicine
    {

        public int Id { get; set; }
        public string Name { get; set; } = string.Empty; // e.g., Urea, DAP, Neem Oil
        public string Type { get; set; } = string.Empty; // Fertilizer, Pesticide, Organic
        public string Composition { get; set; } = string.Empty; // NPK ratio, chemical formula
        public string UsageInstructions { get; set; } = string.Empty;
        public DateTime ExpiryDate { get; set; }
        public decimal Price { get; set; }
    }
}

