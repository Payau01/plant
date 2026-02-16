namespace Clgproj.EventHandlers
{
    public interface IEventHandler
    {

        public interface IEventHandler<TEvent>
        {
            Task HandleAsync(TEvent @event);
        }
    }
}
internal interface IEventHandler<T>
{
}