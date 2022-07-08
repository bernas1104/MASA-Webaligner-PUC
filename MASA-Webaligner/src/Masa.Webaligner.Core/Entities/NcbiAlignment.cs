using Masa.Webaligner.Core.Enums;
using Masa.Webaligner.Core.Events;

namespace Masa.Webaligner.Core.Entities
{
    public sealed class NcbiAlignment : Alignment
    {
        public string FirstSequenceName { get; private set; }
        public string SecondSequenceName { get; private set; }

        #pragma warning disable CS8618
        private NcbiAlignment()
        {
            //
        }
        #pragma warning restore CS8618

        public NcbiAlignment(
            User user, bool onlyStageI, AlignmentStatus alignmentStatus,
            string firstSequenceName, string secondSequenceName
        ) : base(user, onlyStageI, alignmentStatus)
        {
            FirstSequenceName = firstSequenceName;
            SecondSequenceName = secondSequenceName;

            AddEvent(
                new NcbiAlignmentRequested(
                    Id, OnlyStageI,
                    FirstSequenceName,
                    SecondSequenceName
                )
            );
        }
    }
}
