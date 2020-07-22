using Moq;
using RunPath.Test.Core.Photos;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace RunPath.Test.Services.UnitTests.Photos.PhotoServiceTests.GetPhotosAsync
{
    public class CanGetPhotos : PhotoServiceTestBase
    {
        public CanGetPhotos()
            => _mockTypiCodePhotoClient.Setup(c => c.GetPhotosAsync()).ReturnsAsync(new[] { new Photo() });

        [Fact(DisplayName = "Can Get Photos")]
        public async Task Test()
        {
            IEnumerable<Photo> photos = await _photoService.GetPhotosAsync();

            Assert.IsAssignableFrom<IEnumerable<Photo>>(photos);
            _mockTypiCodePhotoClient.Verify(c => c.GetPhotosAsync(), Times.Once);
            _mockTypiCodePhotoClient.VerifyNoOtherCalls();
        }
    }
}
