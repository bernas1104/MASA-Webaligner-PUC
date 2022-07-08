using FluentAssertions;
using Masa.Webaligner.Application.UseCases.CreateAlignment;
using Masa.Webaligner.Core.Entities;
using Masa.Webaligner.Core.Interfaces.Repositories;
using Masa.Webaligner.Shared.Applications;
using Moq;

namespace Masa.Webaligner.Unit.Tests.Application.UseCases
{
    public class CreateNcbiAlignmentUseCaseTest :
        BaseUseCaseTest<IAlignmentsRepository>
    {
        private readonly ICreateNcbiAlignmentUseCase _useCase;

        public CreateNcbiAlignmentUseCaseTest()
        {
            _useCase = new CreateNcbiAlignmentUseCase(
                _repository.Object,
                _unitOfWork.Object
            );
        }

        [Fact]
        public async void CreateNcbiAlignmentUseCase_Should_Create_Alignment_Request()
        {
            // Arrange
            var input = CreateAlignmentsMock.CreateNcbiAlignmentInputFaker;

            // Act
            var output = await _useCase.Execute(input);

            // Assert
            output.Should().NotBeNull();

            _repository.Verify(x => x.Add(It.IsAny<Alignment>()), Times.Once);
            VerifyCommitedTimes(ONCE);
        }

        [Fact]
        public void CreateNcbiAlignmentUseCase_Should_Publish_Alignment_Request_Event()
        {
            // Arrange

            // Act

            // Assert
        }
    }
}
