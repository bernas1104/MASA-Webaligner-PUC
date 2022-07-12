using Bogus;
using Masa.Webaligner.Core.Interfaces.UoW;
using Masa.Webaligner.Infrastructure.MessageBus;
using Moq;

namespace Masa.Webaligner.Unit.Tests.Application.UseCases
{
    public abstract class BaseUseCaseTest<TRepository> where TRepository : class
    {
        public Faker _faker { get; private set; }
        public Mock<TRepository> _repository { get; private set; }
        public Mock<IUnitOfWork> _unitOfWork { get; private set; }
        public Mock<IEventProcessor> _eventProcessor { get; private set; }
        protected const int ONCE = 1;

        protected BaseUseCaseTest()
        {
            _faker = new Faker();
            _repository = new Mock<TRepository>();
            _unitOfWork = new Mock<IUnitOfWork>();
            _eventProcessor = new Mock<IEventProcessor>();
        }

        protected void VerifyCommitedTimes(int times)
        {
            _unitOfWork.Verify(x => x.Commit(), Times.Exactly(times));
        }
    }
}
