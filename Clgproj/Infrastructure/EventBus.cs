using Microsoft.Extensions.DependencyInjection;

namespace Clgproj.Infrastructure
{

    public interface IEventBus
    {
        Task PublishAsync<TEvent>(TEvent @event);
    }

    public class EventBus : IEventBus
    {
        private readonly IServiceProvider _serviceProvider;

        public EventBus(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task PublishAsync<TEvent>(TEvent @event)
        {
            var handler = _serviceProvider.GetService(
                typeof(EventHandlers.PlantWateredEventHandlers)
            );

            foreach (var handler in handlers)
            {
                await handler.HandleAsync(@event);

            }
        }
    }
}
