namespace Clgproj.Model
{
    public class Fertilizer
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public decimal Nitrogen { get; set; }
        public decimal Phosphorus { get; set; }
        public decimal Potassium { get; set; }

        public int StockInKg { get; set; }
        public decimal PricePerKg { get; set; }
        public DateTime ExpiryDate { get; set; }

    }
}
