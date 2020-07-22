using Moq;
using RunPath.Test.Core.Infrastructure;
using RunPath.Test.Core.Typicode;
using Xunit;

namespace RunPath.Test.TypiCode.UnitTests.PhotoClientTests
{
    [Trait("Category", "PhotoClient Tests")]
    public abstract class PhotoClientTestBase
    {
        protected readonly Mock<ITypiCodeConnectionSettings> _mockConnectionSettings;

        protected readonly Mock<IWebClient> _mockWebClient;

        protected readonly Mock<IJsonDeserializer> _mockJsonDeserializer;

        protected readonly PhotoClient _photoClient;

        public PhotoClientTestBase()
            => _photoClient = new PhotoClient(
                (_mockConnectionSettings = new Mock<ITypiCodeConnectionSettings>(MockBehavior.Strict)).Object,
                (_mockWebClient = new Mock<IWebClient>(MockBehavior.Strict)).Object,
                (_mockJsonDeserializer = new Mock<IJsonDeserializer>(MockBehavior.Strict)).Object
            );
    }
}
