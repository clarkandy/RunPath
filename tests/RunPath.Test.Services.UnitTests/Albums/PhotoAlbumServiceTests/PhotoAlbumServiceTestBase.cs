using Microsoft.Extensions.Logging;
using Moq;
using RunPath.Test.Core.TypiCode;
using RunPath.Test.Services.Albums;
using Xunit;

namespace RunPath.Test.Services.UnitTests.Albums.PhotoAlbumServiceTests
{
    [Trait("Category", "PhotoAlbumService Tests")]
    public abstract class PhotoAlbumServiceTestBase
    {
        protected readonly Mock<ITypiCodeAlbumClient> _mockAlbumClient;

        protected readonly Mock<ITypiCodePhotoClient> _mockPhotoClient;

        protected readonly Mock<ILogger<PhotoAlbumService>> _mockLogger;

        protected readonly PhotoAlbumService _photoAlbumService;

        public PhotoAlbumServiceTestBase()
            => _photoAlbumService = new PhotoAlbumService(
                (_mockAlbumClient = new Mock<ITypiCodeAlbumClient>(MockBehavior.Strict)).Object,
                (_mockPhotoClient = new Mock<ITypiCodePhotoClient>(MockBehavior.Strict)).Object,
                (_mockLogger = new Mock<ILogger<PhotoAlbumService>>(MockBehavior.Loose)).Object
            );
    }
}
