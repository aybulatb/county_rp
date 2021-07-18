using CountyRP.ApiGateways.Forum.Infrastructure.Services;
using CountyRP.ApiGateways.Forum.Infrastructure.Services.Interfaces;
using CountyRP.Gateways.Forum.Infrastructure.RestClients.ServiceForum;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Net.Http;

namespace Forum.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            HttpClient httpClient = new();
            services.AddSingleton(new ForumClient(httpClient)
            {
                BaseUrl = "https://localhost:10502"
            });
            services.AddTransient<IForumService, ForumService>();

            services.AddControllers();
            services.AddSwaggerDocument(document =>
            {
                document.Title = "County RP Forum Gateway API";
                document.Version = "v1";
                document.Description = "The County RP Forum Gateway API documentation description.";
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseOpenApi();
            app.UseSwaggerUi3();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
