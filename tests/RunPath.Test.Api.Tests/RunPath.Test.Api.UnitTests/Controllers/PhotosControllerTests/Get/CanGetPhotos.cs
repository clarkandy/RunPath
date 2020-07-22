using Microsoft.AspNetCore.Mvc;
using Moq;
using RunPath.Test.Core.Photos;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace RunPath.Test.Api.UnitTests.Controllers.PhotosControllerTests.Get
{
    public class CanGetPhotos : PhotosControllerTestBase
    {
        public CanGetPhotos()
            => _mockPhotoService.Setup(p => p.GetPhotosAsync()).ReturnsAsync(new[] { new Photo() });

        [Fact(DisplayName = "Can Get Photos")]
        public async Task Test()
        {
            OkObjectResult result = await _photosController.Get() as OkObjectResult;

            Assert.NotNull(result?.Value);
            Assert.IsAssignableFrom<IEnumerable<Photo>>(result.Value);
            _mockPhotoService.Verify(p => p.GetPhotosAsync(), Times.Once);
            _mockPhotoService.VerifyNoOtherCalls();
        }
    }
}
