using Clgproj.Model;

namespace Clgproj.Services.Interfaces
{
    public interface IWateringService
    {
        Task<WateringSchedule> GenerateScheduleAsync(int plantId,
            WateringFrequency frequency);
        Task<bool> ExecuteWateringIfDueAsync(int plantId, object v);
        Task<object?> GenerateScheduleAsync(int plantId);
        object GetWaterFrequency();
        Task<bool> ExecuteWateringIfDueAsync(int plantId, WateringFrequency wateringFrequency);
        WateringFrequency GetWateringFrequency(int plantId);
    }
}
