using Clgproj.Tests.Unit;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework; // ← MUST match your project spelling
                    // Fixed typo in namespace
                    // The error CS0234 indicates that the namespace 'Model' does not exist in the namespace 'Clgproj'.
                    // To fix this, ensure that the 'Model' namespace is correctly defined in your project and that the necessary assembly reference is included.
                    // If the 'Model' namespace is part of your project, verify its location and adjust the namespace accordingly.

// Ensure that the 'Model' namespace exists in the Clgproj project.


namespace Clgproj.Test.Services
{
    internal class InvoiceServiceTests
    {
        private InvoiceDbContext _context = null!;
        private InvoiceService _service = null!;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<InvoiceDbContext>()
                .UseInMemoryDatabase("InvoiceService_Test")
                .Options;

            _context = new InvoiceDbContext(options);
            _service = new InvoiceService(_context);
        }

        [TearDown]
        public void TearDown()
        {
            _context?.Dispose();
        }

        [Test]
        public void GenerateBulkSaleInvoice_Returns_Invoice()
        {
            var invoice = _service.GenerateBulkSaleInvoice(
                "Farmer",
                "Buyer",
                new List<InvoiceItem>());

            Assert.That(invoice, Is.Not.Null);
        }
    }
}

