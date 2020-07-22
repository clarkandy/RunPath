using Moq;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace RunPath.Test.Services.UnitTests.Albums.AlbumServiceTests.GetAlbumsAsync
{
    public class CannotGetAlbumsWhenOffline : AlbumServiceTestBase
    {
        public CannotGetAlbumsWhenOffline()
            => _mockTypiCodeAlbumClient.Setup(c => c.GetAlbumsAsync()).ThrowsAsync(new WebException());

        [Fact(DisplayName = "Cannot Get Albums When Offline")]
        public async Task Test()
        {
            await Assert.ThrowsAsync<WebException>(() => _albumService.GetAlbumsAsync());
            _mockTypiCodeAlbumClient.Verify(c => c.GetAlbumsAsync(), Times.Once);
            _mockTypiCodeAlbumClient.VerifyNoOtherCalls();
        }
    }
}
