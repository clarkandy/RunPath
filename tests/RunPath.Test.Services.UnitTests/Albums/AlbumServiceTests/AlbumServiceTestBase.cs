using Microsoft.Extensions.Logging;
using Moq;
using RunPath.Test.Core.TypiCode;
using RunPath.Test.Services.Albums;
using Xunit;

namespace RunPath.Test.Services.UnitTests.Albums.AlbumServiceTests
{
    [Trait("Category", "AlbumService Tests")]
    public abstract class AlbumServiceTestBase
    {
        protected readonly Mock<ITypiCodeAlbumClient> _mockTypiCodeAlbumClient;

        protected readonly Mock<ILogger<AlbumService>> _mockLogger;

        protected readonly AlbumService _albumService;

        public AlbumServiceTestBase()
        {
            _mockTypiCodeAlbumClient = new Mock<ITypiCodeAlbumClient>(MockBehavior.Strict);
            _mockLogger = new Mock<ILogger<AlbumService>>(MockBehavior.Loose);
            _albumService = new AlbumService(_mockTypiCodeAlbumClient.Object, _mockLogger.Object);
        }
    }
}
