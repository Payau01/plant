using clgproj.UI.Models;
using System.Net.Http.Json;

namespace Clgproj.Ui.Services.Api
{
    public class AnalysisApiService
    {
        private readonly HttpClient _http;

        public AnalysisApiService(HttpClient http)
        {
            _http = http;
        }

        // POST: /api/plant/analyze
        public async Task<PlantAnalysisResultDto?> AnalyzePlantAsync(
            Stream imageStream,
            string fileName)
        {
            using var content = new MultipartFormDataContent();
            content.Add(
                new StreamContent(imageStream),
                "image",
                fileName);

            var response = await _http.PostAsync("/api/plant/analyze", content);

            return await response.Content
                .ReadFromJsonAsync<PlantAnalysisResultDto>();
        }
    }
}
