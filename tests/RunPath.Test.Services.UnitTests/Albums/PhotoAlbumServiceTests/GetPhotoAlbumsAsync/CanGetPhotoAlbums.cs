using Moq;
using RunPath.Test.Core.Albums;
using RunPath.Test.Core.Photos;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace RunPath.Test.Services.UnitTests.Albums.PhotoAlbumServiceTests.GetPhotoAlbumsAsync
{
    public class CanGetPhotoAlbums : PhotoAlbumServiceTestBase
    {
        public CanGetPhotoAlbums()
        {
            _mockAlbumClient.Setup(a => a.GetAlbumsAsync()).ReturnsAsync(new[] { new Album() });
            _mockPhotoClient.Setup(c => c.GetPhotosWithinAlbumAsync(It.IsAny<int>())).ReturnsAsync(new[] { new Photo() });
        }

        [Fact(DisplayName = "Can Get Photo Albums")]
        public async Task Test()
        {
            IEnumerable<Album> albums = await _photoAlbumService.GetPhotoAlbumsAsync();

            Assert.NotNull(albums);
            Assert.All(albums, a => Assert.Single(a.Photos));
            _mockAlbumClient.Verify(c => c.GetAlbumsAsync(), Times.Once);
            _mockPhotoClient.Verify(c => c.GetPhotosWithinAlbumAsync(It.IsAny<int>()), Times.Once);
            _mockAlbumClient.VerifyNoOtherCalls();
            _mockPhotoClient.VerifyNoOtherCalls();
        }
    }
}
