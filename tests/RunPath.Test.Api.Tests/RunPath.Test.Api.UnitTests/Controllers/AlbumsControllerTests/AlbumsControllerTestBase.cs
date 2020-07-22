using Moq;
using RunPath.Test.Api.Controllers;
using RunPath.Test.Core.Albums;
using Xunit;

namespace RunPath.Test.Api.UnitTests.Controllers.AlbumsControllerTests
{
    [Trait("Category", "AlbumsController Tests")]
    public abstract class AlbumsControllerTestBase
    {
        protected readonly Mock<IAlbumService> _mockAlbumService;

        protected readonly AlbumsController _albumsController;

        public AlbumsControllerTestBase()
        {
            _mockAlbumService = new Mock<IAlbumService>(MockBehavior.Strict);
            _albumsController = new AlbumsController(_mockAlbumService.Object);
        }
    }
}
