using RunPath.Test.Api.Controllers;
using Xunit;

namespace RunPath.Test.Api.IntegrationTests.PhotoAlbumsControllerTests
{
    [Trait("Category", "PhotoAlbumsController Integration Tests")]
    public abstract class PhotoAlbumsControllerTestBase
    {
        protected readonly PhotoAlbumsController _photoAlbumsController;

        public PhotoAlbumsControllerTestBase(DependencyFixture dependencyFixture)
            => _photoAlbumsController = dependencyFixture.Resolve<PhotoAlbumsController>();
    }
}
