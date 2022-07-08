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
        public string? CancellationReason { get; private set; }

        #pragma warning disable CS8618
        protected Alignment()
        {
            //
        }
        #pragma warning restore CS8618

        protected Alignment(
            User user, bool onlyStageI,
            AlignmentStatus status
        )
        {
            Id = Guid.NewGuid();
            User = user;
            OnlyStageI = onlyStageI;
            Status = status;
            CancellationReason = default;
            CreatedAt = DateTime.Now;
            UpdatedAt = CreatedAt;
        }

        public void SetAsWaitingSequences()
        {
            Status = AlignmentStatus.WaitingSequences;
        }

        public void SetAsInProcess()
        {
            Status = AlignmentStatus.InProcess;
        }

        public void SetAsFinished()
        {
            Status = AlignmentStatus.Finished;
        }

        public void SetAsCancelled(string cancellationReason)
        {
            Status = AlignmentStatus.Cancelled;
            CancellationReason = cancellationReason;
        }
    }
}
