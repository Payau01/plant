using clgproj.UI.Models;
using System.Net.Http.Json;


namespace Clgproj.Ui.Services.Api
{
    public class FertilizerApiService
    {
        private readonly HttpClient _http;

        public FertilizerApiService(HttpClient http)
        {
            _http = http;
        }

        // POST: /api/fertilizer/usage
        public async Task RecordUsageAsync(FertilizerUsageDto usage)
        {
            await _http.PostAsJsonAsync("/api/fertilizer/usage", usage);
        }

        // GET: /api/fertilizer/usage/{plantId}
        public async Task<List<FertilizerUsageDto>> GetUsageHistoryAsync(int plantId)
        {
            return await _http.GetFromJsonAsync<List<FertilizerUsageDto>>(
                $"/api/fertilizer/usage/{plantId}")
                   ?? new List<FertilizerUsageDto>();
        }
    }
}
