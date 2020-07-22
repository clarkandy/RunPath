using Moq;
using RunPath.Test.Core.Albums;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace RunPath.Test.TypiCode.UnitTests.AlbumClientTests.GetUsersAlbumsAsync
{
    public class CanGetAlbums : AlbumClientTestBase
    {
        public CanGetAlbums()
        {
            _mockConnectionSettings.SetupGet(s => s.Url).Returns("http://myurl.com");
            _mockWebClient.Setup(c => c.DownloadAsync("http://myurl.com/albums?userId=1")).ReturnsAsync("[{ }]");
            _mockJsonDeserializer.Setup(d => d.DeserializeAsync<IEnumerable<Album>>(It.IsAny<string>())).ReturnsAsync(new[] { new Album() });
        }

        [Fact(DisplayName = "Can Get Users Albums")]
        public async Task Test()
        {
            IEnumerable<Album> albums = await _albumClient.GetUsersAlbumsAsync(1);

            Assert.NotNull(albums);
            _mockConnectionSettings.VerifyGet(s => s.Url, Times.Once);
            _mockWebClient.Verify(c => c.DownloadAsync("http://myurl.com/albums?userId=1"), Times.Once);
            _mockJsonDeserializer.Verify(d => d.DeserializeAsync<IEnumerable<Album>>(It.IsAny<string>()), Times.Once);
            _mockConnectionSettings.VerifyNoOtherCalls();
            _mockWebClient.VerifyNoOtherCalls();
            _mockJsonDeserializer.VerifyNoOtherCalls();
        }
    }
}
