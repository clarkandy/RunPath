using System.Collections.Generic;
using System.Threading.Tasks;

namespace RunPath.Test.Core.Albums
{
    public interface IPhotoAlbumService
    {
        Task<IEnumerable<Album>> GetPhotoAlbumsAsync();

        Task<IEnumerable<Album>> GetUsersPhotoAlbumsAsync(int userId);
    }
}
