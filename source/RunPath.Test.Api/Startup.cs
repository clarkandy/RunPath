using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using RunPath.Test.Core.Typicode;
using RunPath.Test.Infrastructure;
using RunPath.Test.Services;
using RunPath.Test.TypiCode;

namespace RunPath.Test.Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
            => Configuration = configuration;

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<ITypiCodeConnectionSettings>(Configuration.GetSection(nameof(TypiCodeConnectionSettings)).Get<TypiCodeConnectionSettings>())
                    .AddServices()
                    .AddTypiCode()
                    .AddInfrastructure()
                    .AddMvc()
                    .AddJsonOptions(o => o.SerializerSettings.Formatting = Formatting.Indented)
                    .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();
            else
                app.UseHsts();

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
