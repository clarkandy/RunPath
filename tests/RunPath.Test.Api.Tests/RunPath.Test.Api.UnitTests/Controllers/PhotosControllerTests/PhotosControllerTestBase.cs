using Moq;
using RunPath.Test.Api.Controllers;
using RunPath.Test.Core.Photos;
using Xunit;

namespace RunPath.Test.Api.UnitTests.Controllers.PhotosControllerTests
{
    [Trait("Category", "PhotosController Tests")]
    public abstract class PhotosControllerTestBase
    {
        protected readonly Mock<IPhotoService> _mockPhotoService;

        protected readonly PhotosController _photosController;

        public PhotosControllerTestBase()
        {
            _mockPhotoService = new Mock<IPhotoService>(MockBehavior.Strict);
            _photosController = new PhotosController(_mockPhotoService.Object);
        }
    }
}
