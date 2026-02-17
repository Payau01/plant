using Clgproj.Model;
using Microsoft.EntityFrameworkCore;

namespace Clgproj.Data
{
    public class invoiceDbContext : DbContext
    {
        public invoiceDbContext(DbContextOptions<InvoiceDbContext> options)
            : base(options)
        { }

          public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceItem> InvoiceItems { get; set; }
      
    }
}
