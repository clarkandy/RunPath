using Moq;
using RunPath.Test.Core.Albums;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace RunPath.Test.Services.UnitTests.Albums.AlbumServiceTests.GetAlbumsAsync
{
    public class CanGetAlbums : AlbumServiceTestBase
    {
        public CanGetAlbums()
            => _mockTypiCodeAlbumClient.Setup(c => c.GetAlbumsAsync()).ReturnsAsync(new[] { new Album() });

        [Fact(DisplayName = "Can Get Albums")]
        public async Task Test()
        {
            IEnumerable<Album> albums = await _albumService.GetAlbumsAsync();

            Assert.IsAssignableFrom<IEnumerable<Album>>(albums);
            _mockTypiCodeAlbumClient.Verify(c => c.GetAlbumsAsync(), Times.Once);
            _mockTypiCodeAlbumClient.VerifyNoOtherCalls();
        }
    }
}
