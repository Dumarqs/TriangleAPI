using Infra.CrossCutting.FileManager.Interfaces;
using Infra.CrossCutting.Logging.Interfaces;
using Moq;
using Service.Services;

namespace Triangle.Tests
{
    public class TriangleServiceTests
    {
        private Mock<ILoggerAdapter<TriangleService>> _logger = new Mock<ILoggerAdapter<TriangleService>>();
        private TriangleService _triangleService;
        private readonly List<string> triangleList;
        private readonly int triangleResult;
        private Mock<ILoadTextFile> _loadTextFile = new Mock<ILoadTextFile>();

        public TriangleServiceTests()
        {
            _triangleService = new TriangleService(_logger.Object, _loadTextFile.Object);

            triangleList = new List<string>
            {
                "5",
                "9 6",
                "4 6 8",
                "0 7 1 5",
                "8 3 1 1 2"
            };

            triangleResult = 30;
        }

        [Fact]
        public async void ShouldReturnExpectedResult()
        {
            // Arrange
            var file = _loadTextFile.Setup(x => x.LoadFile()).Returns(Task.FromResult(triangleList));

            // Act
            var result = await _triangleService.GetMaximumTotalFromTextFile();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(result, triangleResult);
        }
    }
}
