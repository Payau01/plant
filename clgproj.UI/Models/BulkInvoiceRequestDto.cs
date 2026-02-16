using clgproj.UI.Models;

namespace clgproj.UI.Models
{
    public class BulkInvoiceRequestDto
    {
        public string? FarmerName { get; set; }
        public string? BuyerName { get; set; }

        public List<InvoiceItemDto> Items { get; set; }
            = new();
    }
}
