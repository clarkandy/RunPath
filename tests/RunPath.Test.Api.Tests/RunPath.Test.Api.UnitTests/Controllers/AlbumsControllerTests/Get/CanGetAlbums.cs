using Microsoft.AspNetCore.Mvc;
using Moq;
using RunPath.Test.Core.Albums;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace RunPath.Test.Api.UnitTests.Controllers.AlbumsControllerTests.Get
{
    public class CanGetAlbums : AlbumsControllerTestBase
    {
        public CanGetAlbums()
            => _mockAlbumService.Setup(p => p.GetAlbumsAsync()).ReturnsAsync(new[] { new Album() });

        [Fact(DisplayName = "Can Get Albums")]
        public async Task Test()
        {
            OkObjectResult result = await _albumsController.Get() as OkObjectResult;

            Assert.NotNull(result?.Value);
            Assert.IsAssignableFrom<IEnumerable<Album>>(result.Value);
            _mockAlbumService.Verify(p => p.GetAlbumsAsync(), Times.Once);
            _mockAlbumService.VerifyNoOtherCalls();
        }
    }
}
