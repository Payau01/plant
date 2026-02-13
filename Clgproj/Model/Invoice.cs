namespace Clgproj.Model
{
        public class Invoice
    {
            public int Id { get; set; }
            public string InvoiceNumber { get; set; } = string.Empty;

            public string FarmerName { get; set; } = string.Empty;
            public string BuyerName { get; set; } = string.Empty;

            public DateTime InvoiceDate { get; set; }

            public float TotalAmount { get; set; }
        public List<InvoiceItem>? Items { get; internal set; }
        public object TaxAmount { get; internal set; }
        public object GrandTotal { get; internal set; }
    }
}
