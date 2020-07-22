using Microsoft.AspNetCore.Mvc;
using RunPath.Test.Core.Photos;
using System.Threading.Tasks;

namespace RunPath.Test.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PhotosController : ControllerBase
    {
        private readonly IPhotoService _photoService;

        public PhotosController(IPhotoService photoService)
            => _photoService = photoService;

        [HttpGet]
        public async Task<IActionResult> Get()
            => Ok(await _photoService.GetPhotosAsync());
    }
}