using Moq;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace RunPath.Test.Services.UnitTests.Photos.PhotoServiceTests.GetPhotosAsync
{
    public class CannotGetPhotosWhenOffline : PhotoServiceTestBase
    {
        public CannotGetPhotosWhenOffline()
            => _mockTypiCodePhotoClient.Setup(c => c.GetPhotosAsync()).ThrowsAsync(new WebException());

        [Fact(DisplayName = "Cannot Get Photos When Offline")]
        public async Task Test()
        {
            await Assert.ThrowsAsync<WebException>(() => _photoService.GetPhotosAsync());
            _mockTypiCodePhotoClient.Verify(c => c.GetPhotosAsync(), Times.Once);
            _mockTypiCodePhotoClient.VerifyNoOtherCalls();
        }
    }
}
