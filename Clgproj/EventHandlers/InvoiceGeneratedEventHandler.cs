using Clgproj.Data;
using Clgproj.Events;

namespace Clgproj.EventHandlers
{
    public class InvoiceGeneratedEventHandler
    {
        private readonly AppDbContext _context;

        public InvoiceGeneratedEventHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task HandleAsync(InvoiceGeneratedEvent @event)
        {
            Console.WriteLine(
                $"Invoice {@event.InvoiceId} generated. Amount: {@event.GrandTotal}");
            await Task.CompletedTask;
        }
    }
}
