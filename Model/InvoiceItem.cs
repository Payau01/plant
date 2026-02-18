namespace Clgproj.Model
{
    public class InvoiceItem
    {
        internal int Quantity;

        public string ProductName { get; set; } = string.Empty;

        public decimal QuantityKg { get; set; }
        public decimal RatePerKg { get; set; }

        // ✅ Computed property (NOT stored in DB)
        public decimal Amount => Quantity * RatePerKg;

        public int Price { get;  set; }
        public int InvoiceId { get; set; }
        public decimal UnitPrice { get;  set; }
        public decimal TotalPrice { get;  set; }
        public decimal Total { get; internal set; }
    }
}
