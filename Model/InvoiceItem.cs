namespace Clgproj.Model
{
    public class InvoiceItem
    {
        internal int Quantity;

        public string ProductName { get; set; } = string.Empty;

        public float QuantityKg { get; set; }
        public float RatePerKg { get; set; }

        // ✅ Computed property (NOT stored in DB)
        public float Amount => QuantityKg * RatePerKg;

        public int Price { get; internal set; }
        public object? InvoiceId { get; internal set; }
        public object? UnitPrice { get; internal set; }
        public object? TotalPrice { get; internal set; }
    }
}
