using Microsoft.AspNetCore.Mvc;
using Moq;
using RunPath.Test.Core.Albums;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace RunPath.Test.Api.UnitTests.Controllers.PhotoAlbumsControllerTests.Get
{
    public class CanGetUsersPhotoAlbums : PhotoAlbumsControllerTestBase
    {
        public CanGetUsersPhotoAlbums()
            => _mockPhotoAlbumService.Setup(p => p.GetUsersPhotoAlbumsAsync(It.IsAny<int>())).ReturnsAsync(new[] { new Album() });

        [Fact(DisplayName = "Can Get Users Photo Albums")]
        public async Task Test()
        {
            OkObjectResult result = await _photosController.Get(1) as OkObjectResult;

            Assert.NotNull(result?.Value);
            Assert.IsAssignableFrom<IEnumerable<Album>>(result.Value);
            _mockPhotoAlbumService.Verify(p => p.GetUsersPhotoAlbumsAsync(It.IsAny<int>()), Times.Once);
            _mockPhotoAlbumService.VerifyNoOtherCalls();
        }
    }
}
