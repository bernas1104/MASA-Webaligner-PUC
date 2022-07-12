using Masa.Webaligner.Core.Interfaces.Events;
using Masa.Webaligner.Infrastructure.MessageBus.Implementations;

namespace Masa.Webaligner.Infrastructure.MessageBus
{
    public class EventProcessor : IEventProcessor
    {
        private readonly IMessageBusClient _client;

        public EventProcessor(IMessageBusClient client)
        {
            _client = client;
        }

        public void Process(IEnumerable<IDomainEvent> events)
        {
            throw new NotImplementedException();
        }
    }
}
