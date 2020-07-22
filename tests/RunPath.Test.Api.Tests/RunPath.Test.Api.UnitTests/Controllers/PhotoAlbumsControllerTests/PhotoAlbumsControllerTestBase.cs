using Moq;
using RunPath.Test.Api.Controllers;
using RunPath.Test.Core.Albums;
using Xunit;

namespace RunPath.Test.Api.UnitTests.Controllers.PhotoAlbumsControllerTests
{
    [Trait("Category", "PhotoAlbumsController Tests")]
    public abstract class PhotoAlbumsControllerTestBase
    {
        protected readonly Mock<IPhotoAlbumService> _mockPhotoAlbumService;

        protected readonly PhotoAlbumsController _photosController;

        public PhotoAlbumsControllerTestBase()
        {
            _mockPhotoAlbumService = new Mock<IPhotoAlbumService>(MockBehavior.Strict);
            _photosController = new PhotoAlbumsController(_mockPhotoAlbumService.Object);
        }
    }
}
