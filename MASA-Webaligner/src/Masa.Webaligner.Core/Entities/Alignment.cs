using Masa.Webaligner.Core.Enums;

namespace Masa.Webaligner.Core.Entities
{
    public class Alignment : AggregateRoot
    {
        public User User { get; private set; }
        public bool OnlyStageI { get; private set; }
        public AlignmentStatus Status { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }

        #pragma warning disable CS8618
        protected Alignment()
        {
            //
        }
        #pragma warning restore CS8618

        protected Alignment(
            Guid? id,
            User user,
            bool onlyStageI,
            AlignmentStatus status,
            DateTime? createdAt,
            DateTime? updatedAt
        )
        {
            Id = id ?? Guid.NewGuid();
            User = user;
            OnlyStageI = onlyStageI;
            Status = status;
            CreatedAt = createdAt ?? DateTime.Now;
            UpdatedAt = updatedAt ?? CreatedAt;
        }
    }
}
