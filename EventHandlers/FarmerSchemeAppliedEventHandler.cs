using Clgproj.Events;

namespace Clgproj.EventHandlers
{
    public class FarmerSchemeAppliedEventHandler : IEventHandler<FarmerSchemeAppliedEvent>
    {
        public async Task HandleAsync(
            FarmerSchemeAppliedEvent @event)
        {
            Console.WriteLine(
                $"[EVENT] Farmer {@event.FarmerId} applied for Scheme {@event.SchemeId}");

            // Future:
            // - Send notification
            // - Write audit log

            await Task.CompletedTask;
        }
    }
}

