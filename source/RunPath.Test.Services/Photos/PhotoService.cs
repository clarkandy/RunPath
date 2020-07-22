using Microsoft.Extensions.Logging;
using RunPath.Test.Core.Photos;
using RunPath.Test.Core.TypiCode;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace RunPath.Test.Services.Photos
{
    public class PhotoService : ServiceBase, IPhotoService
    {
        private readonly ITypiCodePhotoClient _typiCodePhotoClient;

        public PhotoService(ITypiCodePhotoClient typiCodePhotoClient, ILogger<PhotoService> logger)
            : base(logger)
        {
            _typiCodePhotoClient = typiCodePhotoClient;
        }

        public async Task<IEnumerable<Photo>> GetPhotosAsync()
        {
            try
            {
                return await _typiCodePhotoClient.GetPhotosAsync();
            }
            catch (WebException webException)
            {
                _logger.LogError(webException, "Error Getting Photos");

                throw;
            }
        }
    }
}
