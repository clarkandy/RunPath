using Microsoft.AspNetCore.Mvc;
using RunPath.Test.Core.Albums;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace RunPath.Test.Api.IntegrationTests.PhotoAlbumsControllerTests.Get
{
    public class CanGetPhotoAlbums : PhotoAlbumsControllerTestBase, IClassFixture<DependencyFixture>
    {
        public CanGetPhotoAlbums(DependencyFixture dependencyFixture)
            : base(dependencyFixture)
        {
        }

        [Fact(DisplayName = "Can Get Photo Albums")]
        public async Task Test()
        {
            OkObjectResult okResult = await _photoAlbumsController.Get() as OkObjectResult;

            Assert.NotNull(okResult);
            Assert.IsAssignableFrom<IEnumerable<Album>>(okResult.Value);
        }
    }
}
