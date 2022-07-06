using Masa.Webaligner.Core.Interfaces.Events;

namespace Masa.Webaligner.Core.Entities
{
    public abstract class AggregateRoot : IEntityBase
    {
        public Guid Id { get; protected set; }
        public IReadOnlyCollection<IDomainEvent> Events => _events;
        private List<IDomainEvent> _events = new List<IDomainEvent>();

        protected void AddEvent(IDomainEvent @event)
        {
            _events.Add(@event);
        }
    }
}
