namespace clgproj.UI.Models
{
    public class InvoiceItemDto
    {
        public string? ItemName { get; set; }
        public int Quantity { get; set; }
        public decimal PricePerUnit { get; set; }

        public decimal TotalPrice => Quantity * PricePerUnit;
    }
}
