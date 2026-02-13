namespace Clgproj.Events
{
    public class InvoiceGeneratedEvent
    {
        public int InvoiceId { get; }
        public decimal GrandTotal { get; }
        public DateTime GeneratedOn { get; }

        public InvoiceGeneratedEvent(int invoiceId, decimal grandTotal)
        {
            InvoiceId = invoiceId;
            GrandTotal = grandTotal;
            GeneratedOn = DateTime.UtcNow;
        }
    }
}