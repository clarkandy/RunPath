using Microsoft.Extensions.DependencyInjection;
using RunPath.Test.Core.TypiCode;

namespace RunPath.Test.TypiCode
{
    public static class DependencyConfiguration
    {
        public static IServiceCollection AddTypiCode(this IServiceCollection services)
            => services.AddScoped<ITypiCodeAlbumClient, AlbumClient>()
                       .AddScoped<ITypiCodePhotoClient, PhotoClient>();
    }
}
