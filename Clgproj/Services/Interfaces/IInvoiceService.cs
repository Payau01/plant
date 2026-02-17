using Clgproj.Model;

public interface IinvoiceService
{
    Task<Invoice> GenerateBulkSaleInvoiceAsync(
        string farmerName,
        string buyerName,
        List<InvoiceItem> items);

    Task<Invoice> CreateInvoiceAsync(Invoice invoice);
    Task<Invoice?> GetInvoiceByIdAsync(int id);
    Task<IEnumerable<Invoice>> GetAllInvoicesAsync();
    Task<bool> UpdateInvoiceAsync(Invoice invoice);
    Task<bool> DeleteInvoiceAsync(int id);
    Task<decimal> CalculateTotalAmountAsync(int invoiceId);
}
