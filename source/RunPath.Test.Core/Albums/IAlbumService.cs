using System.Collections.Generic;
using System.Threading.Tasks;

namespace RunPath.Test.Core.Albums
{
    public interface IAlbumService
    {
        Task<IEnumerable<Album>> GetAlbumsAsync();
    }
}
