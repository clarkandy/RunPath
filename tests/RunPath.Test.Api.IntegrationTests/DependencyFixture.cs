using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RunPath.Test.Api.Controllers;
using System;

namespace RunPath.Test.Api.IntegrationTests
{
    public class DependencyFixture : IDisposable
    {
        private readonly IServiceScope _serviceScope;

        public DependencyFixture()
        {
            ServiceCollection serviceCollection = new ServiceCollection();
            Startup startup = new Startup(
                new ConfigurationBuilder()
                    .AddJsonFile("appSettings.json", false)
                    .Build()
            );

            startup.ConfigureServices(serviceCollection);
            serviceCollection.AddTransient<PhotoAlbumsController>()
                             .AddTransient<AlbumsController>()
                             .AddTransient<PhotosController>()
                             .AddLogging();

            _serviceScope = serviceCollection.BuildServiceProvider().CreateScope();
        }

        public T Resolve<T>()
            => _serviceScope.ServiceProvider.GetRequiredService<T>();

        public void Dispose()
            => _serviceScope.Dispose();
    }
}
