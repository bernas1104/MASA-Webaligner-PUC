using Masa.Webaligner.Core.Interfaces.Events;

namespace Masa.Webaligner.Core.Events
{
    public sealed class NcbiAlignmentRequested : AlignmentRequested,
        IDomainEvent
    {
        public string FirstSequenceName { get; private set; }
        public string SecondSequenceName { get; private set; }

        public NcbiAlignmentRequested(
            Guid id, bool onlyStageI,
            string firstSequenceName,
            string secondSequenceName
        ) : base(id, onlyStageI)
        {
            FirstSequenceName = firstSequenceName;
            SecondSequenceName = secondSequenceName;
        }
    }
}
