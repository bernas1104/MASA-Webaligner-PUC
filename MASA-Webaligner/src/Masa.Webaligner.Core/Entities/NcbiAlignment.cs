using Masa.Webaligner.Core.Enums;

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
            Guid? id,
            User user,
            bool onlyStageI,
            AlignmentStatus alignmentStatus,
            string firstSequenceName,
            string secondSequenceName,
            DateTime? createdAt,
            DateTime? updatedAt
        ) : base(id, user, onlyStageI, alignmentStatus, createdAt, updatedAt)
        {
            FirstSequenceName = firstSequenceName;
            SecondSequenceName = secondSequenceName;
        }
    }
}
