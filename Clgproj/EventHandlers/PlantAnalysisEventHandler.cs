using Clgproj.Data;
using Clgproj.Events;
using Clgproj.Model;

namespace Clgproj.EventHandlers
{
    public class PlantAnalysisEventHandler
    {
        private readonly AppDbContext _context;

        public PlantAnalysisEventHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task HandleAsync(PlantAnalysisEvent @event)
        {
            _context.PlantAnalysisResults.Add(new PlantAnalysisResult
            {
                PlantId = @event.PlantId,
                HealthStatus = @event.HealthStatus,
                Confidence = @event.Confidence
            });

            await _context.SaveChangesAsync();
        }
    }
}
