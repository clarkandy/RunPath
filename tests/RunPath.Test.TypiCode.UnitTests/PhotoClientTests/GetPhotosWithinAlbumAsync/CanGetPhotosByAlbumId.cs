using Moq;
using RunPath.Test.Core.Photos;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace RunPath.Test.TypiCode.UnitTests.PhotoClientTests.GetPhotosWithinAlbumAsync
{
    public class GetPhotosWithinAlbum : PhotoClientTestBase
    {
        public GetPhotosWithinAlbum()
        {
            _mockConnectionSettings.SetupGet(s => s.Url).Returns("http://myurl.com");
            _mockWebClient.Setup(c => c.DownloadAsync("http://myurl.com/photos?albumId=1")).ReturnsAsync("[{ }]");
            _mockJsonDeserializer.Setup(d => d.DeserializeAsync<IEnumerable<Photo>>(It.IsAny<string>())).ReturnsAsync(new[] { new Photo() });
        }

        [Fact(DisplayName = "Get Photos Within Album")]
        public async Task Test()
        {
            IEnumerable<Photo> photos = await _photoClient.GetPhotosWithinAlbumAsync(1);

            Assert.NotNull(photos);
            _mockConnectionSettings.VerifyGet(s => s.Url, Times.Once);
            _mockWebClient.Verify(c => c.DownloadAsync("http://myurl.com/photos?albumId=1"), Times.Once);
            _mockJsonDeserializer.Verify(d => d.DeserializeAsync<IEnumerable<Photo>>(It.IsAny<string>()), Times.Once);
            _mockConnectionSettings.VerifyNoOtherCalls();
            _mockWebClient.VerifyNoOtherCalls();
            _mockJsonDeserializer.VerifyNoOtherCalls();
        }
    }
}
