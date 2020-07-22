using Microsoft.Extensions.Logging;
using RunPath.Test.Core.Albums;
using RunPath.Test.Core.TypiCode;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace RunPath.Test.Services.Albums
{
    public class PhotoAlbumService : ServiceBase, IPhotoAlbumService
    {
        private readonly ITypiCodeAlbumClient _albumClient;

        private readonly ITypiCodePhotoClient _photoClient;

        public PhotoAlbumService(ITypiCodeAlbumClient albumClient, ITypiCodePhotoClient photoClient, ILogger<PhotoAlbumService> logger)
            : base(logger)
        {
            _albumClient = albumClient;
            _photoClient = photoClient;
        }

        public async Task<IEnumerable<Album>> GetPhotoAlbumsAsync()
        {
            try
            {
                return await DownloadPhotos(await _albumClient.GetAlbumsAsync());
            }
            catch (WebException webException)
            {
                _logger.LogError(webException, "Error Getting Photos");

                throw;
            }
        }

        public async Task<IEnumerable<Album>> GetUsersPhotoAlbumsAsync(int userId)
        {
            try
            {
                return await DownloadPhotos(await _albumClient.GetUsersAlbumsAsync(userId));
            }
            catch (WebException webException)
            {
                _logger.LogError(webException, "Error Getting Photos");

                throw;
            }
        }

        private async Task<IEnumerable<Album>> DownloadPhotos(IEnumerable<Album> albums)
        {
            foreach (Album album in albums)
                album.AddPhotos(await _photoClient.GetPhotosWithinAlbumAsync(album.Id));

            return albums;
        }
    }
}
