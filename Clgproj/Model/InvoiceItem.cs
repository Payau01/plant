namespace Clgproj.Model
{
    public class invoiceItem
    {
         public int Quantity;

        public string ProductName { get; set; } = string.Empty;

        public decimal QuantityKg { get; set; }
        public decimal RatePerKg { get; set; }

        // ✅ Computed property (NOT stored in DB)
        public decimal Amount => QuantityKg * RatePerKg;

        public int Price { get; internal set; }
        public decimal InvoiceId { get;  set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
