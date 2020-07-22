using System.Collections.Generic;
using System.Threading.Tasks;

namespace RunPath.Test.Core.Photos
{
    public interface IPhotoService
    {
        Task<IEnumerable<Photo>> GetPhotosAsync();
    }
}
