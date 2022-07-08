using Masa.Webaligner.Core.Interfaces.Events;

namespace Masa.Webaligner.Core.Events
{
    public abstract class AlignmentRequested : IDomainEvent
    {
        public Guid Id { get; private set; }
        public bool OnlyStageI { get; private set; }

        protected AlignmentRequested(Guid id, bool onlyStageI)
        {
            Id = id;
            OnlyStageI = onlyStageI;
        }
    }
}
