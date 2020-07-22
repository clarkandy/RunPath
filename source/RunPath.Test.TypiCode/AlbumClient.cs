using RunPath.Test.Core.Albums;
using RunPath.Test.Core.Infrastructure;
using RunPath.Test.Core.Typicode;
using RunPath.Test.Core.TypiCode;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RunPath.Test.TypiCode
{
    public class AlbumClient : TypiCodeClient, ITypiCodeAlbumClient
    {
        public override string RelativePath => "albums";

        public AlbumClient(ITypiCodeConnectionSettings connectionSettings, IWebClient webClient, IJsonDeserializer jsonDeserializer)
            : base(connectionSettings, webClient, jsonDeserializer)
        {
        }

        public async Task<IEnumerable<Album>> GetAlbumsAsync()
             => await Get<IEnumerable<Album>>();

        public async Task<IEnumerable<Album>> GetUsersAlbumsAsync(int userId)
             => await Get<IEnumerable<Album>>($"?userId={userId}");
    }
}