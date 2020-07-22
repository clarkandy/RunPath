using RunPath.Test.Core.Albums;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RunPath.Test.Core.TypiCode
{
    public interface ITypiCodeAlbumClient
    {
        Task<IEnumerable<Album>> GetAlbumsAsync();

        Task<IEnumerable<Album>> GetUsersAlbumsAsync(int userId);
    }
}
