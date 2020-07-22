using Microsoft.Extensions.DependencyInjection;
using RunPath.Test.Core.Infrastructure;
using System.Net;

namespace RunPath.Test.Infrastructure
{
    public static class DependencyConfiguration
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
            => services.AddScoped<IWebClient, WebClientWrapper>()
                       .AddSingleton<IJsonDeserializer, JsonDeserializer>()
                       .AddScoped<WebClient>();
    }
}
