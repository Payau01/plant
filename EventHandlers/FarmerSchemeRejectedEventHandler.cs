using Clgproj.Events;

namespace Clgproj.EventHandlers
{
        public class FarmerSchemeRejectedEventHandler
            : IEventHandler<FarmerSchemeRejectedEvent>
        {
            public async Task HandleAsync(
                FarmerSchemeRejectedEvent @event)
            {
                Console.WriteLine(
                    $"[EVENT] Application {@event.ApplicationId} REJECTED");

                // Future:
                // - Notify farmer with reason

                await Task.CompletedTask;
            }
        }
    }

