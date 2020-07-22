using RunPath.Test.Api.Controllers;
using Xunit;

namespace RunPath.Test.Api.IntegrationTests.PhotosControllerTests
{
    [Trait("Category", "PhotosController Integration Tests")]
    public abstract class PhotosControllerTestBase
    {
        protected readonly PhotosController _photosController;

        public PhotosControllerTestBase(DependencyFixture dependencyFixture)
            => _photosController = dependencyFixture.Resolve<PhotosController>();
    }
}
