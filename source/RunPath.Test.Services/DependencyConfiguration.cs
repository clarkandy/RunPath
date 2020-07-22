using Microsoft.Extensions.DependencyInjection;
using RunPath.Test.Core.Albums;
using RunPath.Test.Core.Photos;
using RunPath.Test.Services.Albums;
using RunPath.Test.Services.Photos;

namespace RunPath.Test.Services
{
    public static class DependencyConfiguration
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
            => services.AddScoped<IPhotoAlbumService, PhotoAlbumService>()
                       .AddScoped<IPhotoService, PhotoService>()
                       .AddScoped<IAlbumService, AlbumService>();
    }
}
