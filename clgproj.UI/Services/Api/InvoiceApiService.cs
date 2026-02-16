using clgproj.UI.Models;
using System.Net.Http.Json;


namespace Clgproj.Ui.Services.Api
{
    public class InvoiceApiService
    {
        private readonly HttpClient _http;

        public InvoiceApiService(HttpClient http)
        {
            _http = http;
        }

        // POST: /api/invoices/bulk-sale
        public async Task<InvoiceDto?> GenerateBulkInvoiceAsync(
            BulkInvoiceRequestDto request)
        {
            var response = await _http.PostAsJsonAsync(
                "/api/invoices/bulk-sale", request);

            return await response.Content.ReadFromJsonAsync<InvoiceDto>();
        }

        // GET: /api/invoices
        public async Task<List<InvoiceDto>> GetInvoicesAsync()
        {
            return await _http.GetFromJsonAsync<List<InvoiceDto>>("/api/invoices")
                   ?? new List<InvoiceDto>();
        }
    }
}
