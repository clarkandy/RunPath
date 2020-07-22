using Microsoft.Extensions.Logging;
using RunPath.Test.Core.Albums;
using RunPath.Test.Core.TypiCode;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace RunPath.Test.Services.Albums
{
    public class AlbumService : ServiceBase, IAlbumService
    {
        private readonly ITypiCodeAlbumClient _typiCodeAlbumClient;

        public AlbumService(ITypiCodeAlbumClient typiCodeAlbumClient, ILogger<AlbumService> logger)
            : base(logger)
        {
            _typiCodeAlbumClient = typiCodeAlbumClient;
        }

        public async Task<IEnumerable<Album>> GetAlbumsAsync()
        {
            try
            {
                return await _typiCodeAlbumClient.GetAlbumsAsync();
            }
            catch (WebException webException)
            {
                _logger.LogError(webException, "Error Getting Photos");

                throw;
            }
        }
    }
}
