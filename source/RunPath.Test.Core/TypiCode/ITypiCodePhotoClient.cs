using RunPath.Test.Core.Photos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RunPath.Test.Core.TypiCode
{
    public interface ITypiCodePhotoClient
    {
        Task<IEnumerable<Photo>> GetPhotosAsync();

        Task<IEnumerable<Photo>> GetPhotosWithinAlbumAsync(int albumId);
    }
}
