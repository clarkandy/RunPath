using Microsoft.AspNetCore.Mvc;
using RunPath.Test.Core.Albums;
using System.Threading.Tasks;

namespace RunPath.Test.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AlbumsController : ControllerBase
    {
        private readonly IAlbumService _albumService;

        public AlbumsController(IAlbumService albumService)
            => _albumService = albumService;

        [HttpGet]
        public async Task<IActionResult> Get()
            => Ok(await _albumService.GetAlbumsAsync());
    }
}