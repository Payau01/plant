using clgproj.UI.Models;
using System.Net.Http.Json;
using static System.Net.WebRequestMethods;

namespace clgproj.UI.Services.Api
{
    public class PlantApiService
    {
        private readonly HttpClient _http;

        public PlantApiService(HttpClient http)
        {
            _http = http;
        }


        public async Task<List<PlantDto>> GetPlantsAsync()
        {
            return await _http.GetFromJsonAsync<List<PlantDto>>("/api/plants")
                   ?? new List<PlantDto>();
        }

        public async Task<PlantDto?> GetPlantAsync(int id)
        {
            return await _http.GetFromJsonAsync<PlantDto>(
                $"/api/plants/{id}");
        }

    }
}

