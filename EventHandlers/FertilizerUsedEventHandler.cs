using Clgproj.Data;
using Clgproj.Events;
using Clgproj.Model;

namespace Clgproj.EventHandlers
{
    public class FertilizerUsedEventHandler
    {

        private readonly AppDbContext _context;

        public FertilizerUsedEventHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task HandleAsync(FertilizerUsedEvent @event)
        {
            _context.PlantHistories.Add(new PlantHistory
            {
                PlantId = @event.PlantId,
                EventType = "Fertilizer Applied",
                Description = $"{@event.FertilizerName} - {@event.QuantityInGrams} grams",
                EventDate = @event.AppliedOn
            });

            await _context.SaveChangesAsync();
        }
    }
}
