using RunPath.Test.Core.Infrastructure;
using RunPath.Test.Core.Photos;
using RunPath.Test.Core.Typicode;
using RunPath.Test.Core.TypiCode;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RunPath.Test.TypiCode
{
    public class PhotoClient : TypiCodeClient, ITypiCodePhotoClient
    {
        public override string RelativePath => "photos";

        public PhotoClient(ITypiCodeConnectionSettings connectionSettings, IWebClient webClient, IJsonDeserializer jsonDeserializer)
            : base(connectionSettings, webClient, jsonDeserializer)
        {
        }

        public async Task<IEnumerable<Photo>> GetPhotosAsync()
            => await Get<IEnumerable<Photo>>();

        public async Task<IEnumerable<Photo>> GetPhotosWithinAlbumAsync(int albumId)
            => await Get<IEnumerable<Photo>>($"?albumId={albumId}");
    }
}