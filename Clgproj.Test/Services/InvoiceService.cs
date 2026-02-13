using Clgproj.Tests.Unit;

namespace Clgproj.Tests.Unit
{


    public class InvoiceService : IInvoiceService
    {
        private readonly InvoiceDbContext _context;

        public InvoiceService(InvoiceDbContext context)
        {
            _context = context;
        }
    }

}