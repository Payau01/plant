namespace Clgproj.Model
{
        public class Invoice
    {
            public int Id { get; set; }
            public string InvoiceNumber { get; set; } = string.Empty;

            public string FarmerName { get; set; } = string.Empty;
            public string BuyerName { get; set; } = string.Empty;

            public DateTime InvoiceDate { get; set; }

            public decimal TotalAmount { get; set; }
            public decimal TaxAmount { get;  set; }
            public decimal GrandTotal { get; set; }

             // Navigation property
            public List<InvoiceItem> Items { get; set; } = new();

    }
}
