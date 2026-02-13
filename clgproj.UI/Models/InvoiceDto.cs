using clgproj.UI.Models;

namespace clgproj.UI.Models
{
    public class InvoiceDto
    {
        public int Id { get; set; }
        public string? FarmerName { get; set; }
        public string? BuyerName { get; set; }
        public DateTime InvoiceDate { get; set; }

        public List<InvoiceItemDto> Items { get; set; }
            = new();

        public decimal TotalAmount =>
            Items.Sum(i => i.TotalPrice);
    }
}
