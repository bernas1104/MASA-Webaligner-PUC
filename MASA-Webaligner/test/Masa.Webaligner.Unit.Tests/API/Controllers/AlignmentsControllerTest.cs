using FluentAssertions;
using Masa.Webaligner.API.Controllers.V1;
using Masa.Webaligner.Application.UseCases.CreateAlignment;
using Masa.Webaligner.Shared.Applications;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Masa.Webaligner.Unit.Tests.API.Controllers
{
    public class AlignmentsControllerTest :
        BaseControllerTest<AlignmentsController>
    {
        private readonly AlignmentsController _controller;

        public AlignmentsControllerTest()
        {
            _controller = new AlignmentsController(_log.Object);
        }

        [Fact]
        public async void AlignmentsController_Post_Should_Return_Created_Alignment_Creation_Requested()
        {
            // Arrange
            var input = CreateAlignmentsMock.CreateNcbiAlignmentInputFaker;
            var service = new Mock<ICreateNcbiAlignmentUseCase>();

            service.Setup(x => x.Execute(It.IsAny<CreateNcbiAlignmentInput>()))
                .ReturnsAsync(CreateAlignmentsMock.CreateAlignmentOutputFaker);

            // Act
            var response = await _controller.PostNcbi(input, service.Object) as
                ObjectResult;

            // Assert
            response.Should().BeOfType<CreatedResult>();
            response!.Value.Should().BeOfType<CreateAlignmentOutput>();
        }

        [Fact]
        public async void AlignmentsController_Post_Should_Return_BadRequest_Invalid_Create_Alignment_Request()
        {
            // Arrange
            var input = CreateAlignmentsMock.CreateNcbiAlignmentInputFaker;
            var service = new Mock<ICreateNcbiAlignmentUseCase>();

            service.Setup(x => x.Execute(It.IsAny<CreateNcbiAlignmentInput>()))
                .ReturnsAsync((CreateAlignmentOutput?)default);

            // Act
            var response = await _controller.PostNcbi(input, service.Object);

            // Assert
            response.Should().BeOfType<BadRequestResult>();
        }
    }
}
