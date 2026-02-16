using Clgproj.Events;

namespace Clgproj.EventHandlers
{
    public class FarmerSchemeApprovedEventHandler : IEventHandler<FarmerSchemeApprovedEvent>
    {
        public async Task HandleAsync(
            FarmerSchemeApprovedEvent @event)
        {
            Console.WriteLine(
                $"[EVENT] Application {@event.ApplicationId} APPROVED");

            // Future:
            // - Trigger subsidy payment
            // - Notify farmer

            await Task.CompletedTask;
        }
    }
 }

