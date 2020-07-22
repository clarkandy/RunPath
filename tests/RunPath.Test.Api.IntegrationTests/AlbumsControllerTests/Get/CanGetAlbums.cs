using Microsoft.AspNetCore.Mvc;
using RunPath.Test.Core.Albums;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace RunPath.Test.Api.IntegrationTests.AlbumsControllerTests.Get
{
    public class CanGetAlbums : AlbumsControllerTestBase, IClassFixture<DependencyFixture>
    {
        public CanGetAlbums(DependencyFixture dependencyFixture)
            : base(dependencyFixture)
        {
        }

        [Fact(DisplayName = "Can Get Albums")]
        public async Task Test()
        {
            OkObjectResult okResult = await _albumsController.Get() as OkObjectResult;

            Assert.NotNull(okResult);
            Assert.IsAssignableFrom<IEnumerable<Album>>(okResult.Value);
        }
    }
}
