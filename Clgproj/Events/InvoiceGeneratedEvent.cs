namespace Clgproj.Events
{
    public class invoiceGeneratedEvent
    {
        public int InvoiceId { get; }
        public decimal GrandTotal { get; }
        public DateTime GeneratedOn { get; }

        public invoiceGeneratedEvent(int invoiceId, decimal grandTotal)
        {
            InvoiceId = invoiceId;
            GrandTotal = grandTotal;
            GeneratedOn = DateTime.UtcNow;
        }
    }
}