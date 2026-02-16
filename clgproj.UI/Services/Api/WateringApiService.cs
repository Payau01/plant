using clgproj.UI.Models;
using System.Net.Http.Json;


namespace Clgproj.Ui.Services.Api
{
    public class WateringApiService
    {
        private readonly HttpClient _http;

        public WateringApiService(HttpClient http)
        {
            _http = http;
        }

        // POST: /api/plants/{plantId}/watering/schedule
        public async Task<WateringScheduleDto?> GenerateScheduleAsync(int plantId)
        {
            var response = await _http.PostAsync(
                $"/api/plants/{plantId}/watering/schedule", null);

            return await response.Content
                .ReadFromJsonAsync<WateringScheduleDto>();
        }

        // POST: /api/plants/{plantId}/watering/execute
        public async Task<bool> ExecuteWateringAsync(int plantId)
        {
            var response = await _http.PostAsync(
                $"/api/plants/{plantId}/watering/execute", null);

            return response.IsSuccessStatusCode;
        }

        // GET: /api/watering/logs/{plantId}
        public async Task<List<WateringLogDto>> GetWateringLogsAsync(int plantId)
        {
            return await _http.GetFromJsonAsync<List<WateringLogDto>>(
                $"/api/watering/logs/{plantId}")
                   ?? new List<WateringLogDto>();
        }
    }
}
