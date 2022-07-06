using Microsoft.Extensions.Logging;
using Moq;

namespace Masa.Webaligner.Unit.Tests.API.Controllers
{
    public abstract class BaseControllerTest<T> where T : class
    {
        public Mock<ILogger<T>> _log { get; private set; }

        protected BaseControllerTest()
        {
            _log = new Mock<ILogger<T>>();
        }
    }
}
