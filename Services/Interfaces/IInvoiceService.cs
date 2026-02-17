using Clgproj.Model;
using Stripe;
using Invoice = Clgproj.Model.Invoice;

namespace Clgproj.Services.Interfaces
{
    public interface IInvoiceService
    {

        Invoice GenerateBulkSaleInvoice(
            string farmerName,
            string buyerName,
            List<Model.InvoiceItem> items);

        
        Task<Invoice> CreateInvoiceAsync(Model.Invoice invoice);
        Task<Invoice?> GetInvoiceByIdAsync(int id);
        Task<IEnumerable<Invoice>> GetAllInvoicesAsync();
        Task<bool> UpdateInvoiceAsync(Invoice invoice);
        Task<bool> DeleteInvoiceAsync(int id);
        Task<decimal> CalculateTotalAmountAsync(int invoiceId);
        object? GenerateBulkSaleInvoiceAsync(string farmerName, string buyerName, List<Model.InvoiceItem> items);
    }
}
