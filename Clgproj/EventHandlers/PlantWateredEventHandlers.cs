using Clgproj.Data;
using Clgproj.Events;
using Clgproj.Model;

namespace Clgproj.EventHandlers
{
    public class PlantWateredEventHandlers
    {
        private readonly AppDbContext _context;

        public PlantWateredEventHandlers(AppDbContext context)
        {
            _context = context;
        }

        public async Task HandleAsync(PlantWateredEvent @event)
        {
            _context.WateringLogs.Add(new WateringLog
            {
                PlantId = @event.PlantId,
                WaterUsedInLiters = (float)@event.WaterUsedInLiters,
                WateredAt = @event.WateredAt,
                IsAutomatic = true
            });

            _context.PlantHistories.Add(new PlantHistory
            {
                PlantId = @event.PlantId,
                EventType = "Watered",
                Description = $"Plant watered with {@event.WaterUsedInLiters} liters",
                EventDate = @event.WateredAt
            });

            await _context.SaveChangesAsync();
        }
    }
}
       
