using Microsoft.AspNetCore.Mvc;
using RunPath.Test.Core.Albums;
using System.Threading.Tasks;

namespace RunPath.Test.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PhotoAlbumsController : ControllerBase
    {
        private readonly IPhotoAlbumService _photoAlbumService;

        public PhotoAlbumsController(IPhotoAlbumService photoAlbumService)
            => _photoAlbumService = photoAlbumService;

        [HttpGet]
        public async Task<IActionResult> Get()
            => Ok(await _photoAlbumService.GetPhotoAlbumsAsync());

        [HttpGet]
        [Route("{userId}")]
        public async Task<IActionResult> Get(int userId)
            => Ok(await _photoAlbumService.GetUsersPhotoAlbumsAsync(userId));
    }
}