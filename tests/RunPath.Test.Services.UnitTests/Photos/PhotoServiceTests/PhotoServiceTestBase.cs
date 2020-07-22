using Microsoft.Extensions.Logging;
using Moq;
using RunPath.Test.Core.TypiCode;
using RunPath.Test.Services.Photos;
using Xunit;

namespace RunPath.Test.Services.UnitTests.Photos.PhotoServiceTests
{
    [Trait("Category", "PhotoService Tests")]
    public abstract class PhotoServiceTestBase
    {
        protected readonly Mock<ITypiCodePhotoClient> _mockTypiCodePhotoClient;

        protected readonly Mock<ILogger<PhotoService>> _mockLogger;

        protected readonly PhotoService _photoService;

        public PhotoServiceTestBase()
        {
            _mockTypiCodePhotoClient = new Mock<ITypiCodePhotoClient>(MockBehavior.Strict);
            _mockLogger = new Mock<ILogger<PhotoService>>(MockBehavior.Loose);
            _photoService = new PhotoService(_mockTypiCodePhotoClient.Object, _mockLogger.Object);
        }
    }
}
