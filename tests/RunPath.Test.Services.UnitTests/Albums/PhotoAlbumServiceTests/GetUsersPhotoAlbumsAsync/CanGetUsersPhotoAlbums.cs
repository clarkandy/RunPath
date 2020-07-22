using Moq;
using RunPath.Test.Core.Albums;
using RunPath.Test.Core.Photos;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace RunPath.Test.Services.UnitTests.Albums.PhotoAlbumServiceTests.GetUsersPhotoAlbumsAsync
{
    public class CanGetUsersPhotoAlbums : PhotoAlbumServiceTestBase
    {
        public CanGetUsersPhotoAlbums()
        {
            _mockAlbumClient.Setup(a => a.GetUsersAlbumsAsync(It.IsAny<int>())).ReturnsAsync(new[] { new Album() });
            _mockPhotoClient.Setup(c => c.GetPhotosWithinAlbumAsync(It.IsAny<int>())).ReturnsAsync(new[] { new Photo() });
        }

        [Fact(DisplayName = "Can Get Users Photo Albums")]
        public async Task Test()
        {
            IEnumerable<Album> albums = await _photoAlbumService.GetUsersPhotoAlbumsAsync(1);

            Assert.NotNull(albums);
            Assert.All(albums, a => Assert.Single(a.Photos));
            _mockAlbumClient.Verify(c => c.GetUsersAlbumsAsync(It.IsAny<int>()), Times.Once);
            _mockPhotoClient.Verify(c => c.GetPhotosWithinAlbumAsync(It.IsAny<int>()), Times.Once);
            _mockAlbumClient.VerifyNoOtherCalls();
            _mockPhotoClient.VerifyNoOtherCalls();
        }
    }
}
