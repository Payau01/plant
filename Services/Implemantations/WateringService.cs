using Clgproj.Data;
using Clgproj.Model;
using Clgproj.Services.Interfaces;

namespace Clgproj.Services.Implemantations
{
 
    public class WateringService : IWateringService
    {
        private readonly AppDbContext _context;

        public WateringService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<WateringSchedule> GenerateScheduleAsync(int plantId, object wateringFrequency)
        {
            // Example logic (can grow later)
            float liters = 2.5f; // calculated based on plant type, weather, soil

            var schedule = new WateringSchedule
            {
                PlantId = plantId,
                Frequency = WateringFrequency.Daily,
                LitersRequired = liters,
                LastWateredOn = DateTime.UtcNow,
                NextWateringOn = DateTime.UtcNow.AddDays(1)
            };

            _context.WateringSchedules.Add(schedule);
            await _context.SaveChangesAsync();

            return schedule;
        }

        public WateringFrequency GetWateringFrequency(int plantId)
        {
            return _context.WateringSchedules
                .Where(s => s.PlantId == plantId)
                .Select(s => s.Frequency)
                .FirstOrDefault();
        }

        public async Task<bool> ExecuteWateringIfDueAsync(int plantId, WateringFrequency wateringFrequency)
        {
            var schedule = _context.WateringSchedules
                .FirstOrDefault(s => s.PlantId == plantId);

            if (schedule == null || schedule.NextWateringOn > DateTime.UtcNow)
                return false;

            // 🚿 Trigger shower / sprinkler (mocked)
            TriggerSprinkler(schedule.LitersRequired);

            _context.WateringLogs.Add(new WateringLog
            {
                PlantId = plantId,
                WaterUsedInLiters = schedule.LitersRequired,
                WateredAt = DateTime.UtcNow,
                IsAutomatic = true
            });

            schedule.LastWateredOn = DateTime.UtcNow;
            schedule.NextWateringOn = schedule.Frequency switch
            {
                wateringFrequency.Daily => DateTime.UtcNow.AddDays(1),
                WateringFrequency.Weekly => DateTime.UtcNow.AddDays(7),
                WateringFrequency.Monthly => DateTime.UtcNow.AddMonths(1),
                _ => DateTime.UtcNow
            };

            await _context.SaveChangesAsync();
            return true;
        }

        private void TriggerSprinkler(float liters)
        {
            // Placeholder for IoT / hardware integration
            Console.WriteLine($"Sprinkler ON → {liters} liters");
        }

        public Task<WateringSchedule> GenerateScheduleAsync(int plantId)
        {
            throw new NotImplementedException();
        }

        public Task<WateringSchedule> GenerateScheduleAsync(int plantId, WateringFrequency frequency)
        {
            throw new NotImplementedException();
        }

#pragma warning disable CS0473 // Explicit interface implementation matches more than one interface member
        Task<object?> IWateringService.GenerateScheduleAsync(int plantId)
#pragma warning restore CS0473 // Explicit interface implementation matches more than one interface member
        {
            throw new NotImplementedException();
        }
    }
}
