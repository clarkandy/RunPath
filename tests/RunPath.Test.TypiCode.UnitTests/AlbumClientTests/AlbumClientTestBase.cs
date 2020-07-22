using Moq;
using RunPath.Test.Core.Infrastructure;
using RunPath.Test.Core.Typicode;
using Xunit;

namespace RunPath.Test.TypiCode.UnitTests.AlbumClientTests
{
    [Trait("Category", "AlbumClient Tests")]
    public abstract class AlbumClientTestBase
    {
        protected readonly Mock<ITypiCodeConnectionSettings> _mockConnectionSettings;

        protected readonly Mock<IWebClient> _mockWebClient;

        protected readonly Mock<IJsonDeserializer> _mockJsonDeserializer;

        protected readonly AlbumClient _albumClient;

        public AlbumClientTestBase()
            => _albumClient = new AlbumClient(
                (_mockConnectionSettings = new Mock<ITypiCodeConnectionSettings>(MockBehavior.Strict)).Object,
                (_mockWebClient = new Mock<IWebClient>(MockBehavior.Strict)).Object,
                (_mockJsonDeserializer = new Mock<IJsonDeserializer>(MockBehavior.Strict)).Object
            );
    }
}
