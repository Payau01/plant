using Clgproj.Data;
using Clgproj.Model;
using Clgproj.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Clgproj.Services.Implementations
{
    public class InvoiceService : IInvoiceService
    {
        private readonly AppDbContext _context;

        public InvoiceService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Invoice> GenerateBulkSaleInvoiceAsync(
            string farmerName,
            string buyerName,
            List<InvoiceItem> items)
        {
            if (string.IsNullOrWhiteSpace(farmerName))
                throw new ArgumentException("Farmer name is required.");

            if (string.IsNullOrWhiteSpace(buyerName))
                throw new ArgumentException("Buyer name is required.");

            if (items == null || !items.Any())
                throw new ArgumentException("Invoice must contain at least one item.");

            var subtotal = items.Sum(i => i.Total);
            var tax = subtotal * 0.05m; // 5% GST

            var invoice = new Invoice
            {
                InvoiceNumber = $"INV-{DateTime.UtcNow.Ticks}",
                FarmerName = farmerName,
                BuyerName = buyerName,
                InvoiceDate = DateTime.UtcNow,
                Items = items,
                TotalAmount = subtotal,
                TaxAmount = tax,
                GrandTotal = subtotal + tax
            };

            _context.Invoices.Add(invoice);
            await _context.SaveChangesAsync();

            return invoice;
        }

        public async Task<Invoice> CreateInvoiceAsync(Invoice invoice)
        {
            _context.Invoices.Add(invoice);
            await _context.SaveChangesAsync();
            return invoice;
        }

        public async Task<Invoice?> GetInvoiceByIdAsync(int id)
        {
            return await _context.Invoices
                .Include(i => i.Items)
                .FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<IEnumerable<Invoice>> GetAllInvoicesAsync()
        {
            return await _context.Invoices
                .Include(i => i.Items)
                .ToListAsync();
        }

        public async Task<bool> UpdateInvoiceAsync(Invoice invoice)
        {
            _context.Invoices.Update(invoice);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteInvoiceAsync(int id)
        {
            var invoice = await _context.Invoices.FindAsync(id);
            if (invoice == null)
                return false;

            _context.Invoices.Remove(invoice);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<decimal> CalculateTotalAmountAsync(int invoiceId)
        {
            var invoice = await _context.Invoices
                .Include(i => i.Items)
                .FirstOrDefaultAsync(i => i.Id == invoiceId);

            return invoice?.Items.Sum(i => i.Total) ?? 0;
        }

        object? IInvoiceService.GenerateBulkSaleInvoiceAsync(string farmerName, string buyerName, List<InvoiceItem> items)
        {
            return this.GenerateBulkSaleInvoiceAsync(farmerName, buyerName, items);
        }
    }
}
