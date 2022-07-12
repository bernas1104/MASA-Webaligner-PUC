using Masa.Webaligner.Core.Interfaces.Events;

namespace Masa.Webaligner.Infrastructure.MessageBus
{
    public interface IEventProcessor
    {
        void Process(IEnumerable<IDomainEvent> events);
    }
}
