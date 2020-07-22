using RunPath.Test.Api.Controllers;
using Xunit;

namespace RunPath.Test.Api.IntegrationTests.AlbumsControllerTests
{
    [Trait("Category", "AlbumsController Integration Tests")]
    public abstract class AlbumsControllerTestBase
    {
        protected readonly AlbumsController _albumsController;

        public AlbumsControllerTestBase(DependencyFixture dependencyFixture)
            => _albumsController = dependencyFixture.Resolve<AlbumsController>();
    }
}
