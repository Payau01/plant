using Clgproj.Model;

namespace Clgproj.Services.Interfaces
{
    public interface IwateringService
    {
        Task<WateringSchedule> GenerateScheduleAsync(int plantId,
            WateringFrequency frequency);
        Task<bool> ExecuteWateringIfDueAsync(int plantId, object v);
        Task<object?> GenerateScheduleAsync(int plantId);
        object GetWaterFrequency();
    }
}
