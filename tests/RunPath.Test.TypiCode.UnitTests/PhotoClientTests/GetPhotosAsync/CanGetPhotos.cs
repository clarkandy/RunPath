using Moq;
using RunPath.Test.Core.Photos;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace RunPath.Test.TypiCode.UnitTests.PhotoClientTests.GetPhotosAsync
{
    public class CanGetPhotos : PhotoClientTestBase
    {
        public CanGetPhotos()
        {
            _mockConnectionSettings.SetupGet(s => s.Url).Returns("http://myurl.com");
            _mockWebClient.Setup(c => c.DownloadAsync("http://myurl.com/photos")).ReturnsAsync("[{ }]");
            _mockJsonDeserializer.Setup(d => d.DeserializeAsync<IEnumerable<Photo>>(It.IsAny<string>())).ReturnsAsync(new[] { new Photo() });
        }

        [Fact(DisplayName = "Can Get Photos")]
        public async Task Test()
        {
            IEnumerable<Photo> photos = await _photoClient.GetPhotosAsync();

            Assert.NotNull(photos);
            _mockConnectionSettings.VerifyGet(s => s.Url, Times.Once);
            _mockWebClient.Verify(c => c.DownloadAsync("http://myurl.com/photos"), Times.Once);
            _mockJsonDeserializer.Verify(d => d.DeserializeAsync<IEnumerable<Photo>>(It.IsAny<string>()), Times.Once);
            _mockConnectionSettings.VerifyNoOtherCalls();
            _mockWebClient.VerifyNoOtherCalls();
            _mockJsonDeserializer.VerifyNoOtherCalls();
        }
    }
}
