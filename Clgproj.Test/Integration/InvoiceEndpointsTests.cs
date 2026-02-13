using System.Net;
using System.Text;
using System.Text.Json;
using Clgproj.Tests.TestInfrastructure;



namespace Clgproj.Test.Integration
{
    internal class InvoiceEndpointsTests
    {
        private HttpClient _client = null!;
        private CustomWebApplicationFactory _factory = null!;

        [OneTimeSetUp]
        public void Setup()
        {
            _factory = new CustomWebApplicationFactory();
            _client = _factory.CreateClient();
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            _client?.Dispose();
            _factory?.Dispose();
        }

        [Test]
        public async Task Generate_Bulk_Invoice_Returns_OK()
        {
            var request = new BulkInvoiceRequest
            {
                FarmerName = "Payal",
                BuyerName = "Retailer",
                Items = new()
            };

            var json = JsonSerializer.Serialize(request);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _client.PostAsync(
                "/api/invoices/bulk-sale", content);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
    }
}

