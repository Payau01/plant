namespace Clgproj.Model
{
    public class BulkInvoiceRequest
    {

        public string FarmerName { get; set; } = string.Empty;
        public string BuyerName { get; set; } = string.Empty;
        public List<InvoiceItem> Items { get; set; } = new List<InvoiceItem>();
    }
}
