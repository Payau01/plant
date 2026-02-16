using Clgproj.Model;
using Microsoft.EntityFrameworkCore;

namespace Clgproj.Data
{
    public class InvoiceDbContext : DbContext
    {
        public DbSet<Invoice> Invoices 
            => Set<Invoice>();

        public DbSet<InvoiceItem> InvoiceItems
            => Set<InvoiceItem>();
    
    }
}