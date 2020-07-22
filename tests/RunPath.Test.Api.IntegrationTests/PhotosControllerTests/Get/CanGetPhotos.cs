using Microsoft.AspNetCore.Mvc;
using RunPath.Test.Core.Photos;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace RunPath.Test.Api.IntegrationTests.PhotosControllerTests.Get
{
    public class CanGetPhotos : PhotosControllerTestBase, IClassFixture<DependencyFixture>
    {
        public CanGetPhotos(DependencyFixture dependencyFixture)
            : base(dependencyFixture)
        {
        }

        [Fact(DisplayName = "Can Get Photos")]
        public async Task Test()
        {
            OkObjectResult okResult = await _photosController.Get() as OkObjectResult;

            Assert.NotNull(okResult);
            Assert.IsAssignableFrom<IEnumerable<Photo>>(okResult.Value);
        }
    }
}
