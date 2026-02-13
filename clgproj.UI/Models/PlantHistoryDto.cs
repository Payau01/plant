using clgproj.UI.Models;

namespace clgproj.UI.Models
{
    public class PlantHistoryDto
    {
        public int PlantId { get; set; }
        public string? PlantName { get; set; }

        public List<PlantGrowthRecordDto> GrowthRecords { get; set; }
            = new();

        public List<WateringLogDto> WateringLogs { get; set; }
            = new();
    }
}
