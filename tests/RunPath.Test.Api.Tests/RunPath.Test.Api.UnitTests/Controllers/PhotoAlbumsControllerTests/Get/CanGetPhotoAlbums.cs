using Microsoft.AspNetCore.Mvc;
using Moq;
using RunPath.Test.Core.Albums;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace RunPath.Test.Api.UnitTests.Controllers.PhotoAlbumsControllerTests.Get
{
    public class CanGetPhotoAlbums : PhotoAlbumsControllerTestBase
    {
        public CanGetPhotoAlbums()
            => _mockPhotoAlbumService.Setup(p => p.GetPhotoAlbumsAsync()).ReturnsAsync(new[] { new Album() });

        [Fact(DisplayName = "Can Get Photo Albums")]
        public async Task Test()
        {
            OkObjectResult result = await _photosController.Get() as OkObjectResult;

            Assert.NotNull(result?.Value);
            Assert.IsAssignableFrom<IEnumerable<Album>>(result.Value);
            _mockPhotoAlbumService.Verify(p => p.GetPhotoAlbumsAsync(), Times.Once);
            _mockPhotoAlbumService.VerifyNoOtherCalls();
        }
    }
}
