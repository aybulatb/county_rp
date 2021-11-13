using CountyRP.BuildingBlocks.ApiKeyAuthenticationMiddleware;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NSwag;
using NSwag.Generation.Processors.Security;
using System.Collections.Generic;

namespace GameMode.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var apiKeys = Configuration
                .GetSection("ApiKeys")
                .Get<IEnumerable<ApiKeySettings>>();

            services.AddSingleton(apiKeys);

            services.AddControllers();

            services.AddSwaggerDocument(settings =>
            {
                settings.Title = "County RP GameMode ApiGateway API";
                settings.Version = "v1";
                settings.Description = "The County RP GameMode ApiGateway API documentation description.";
                settings.AddSecurity("apiKey", new OpenApiSecurityScheme
                {
                    Type = OpenApiSecuritySchemeType.ApiKey,
                    Name = "Authorization",
                    Description = "Copy 'Bearer ' + valid api key into field",
                    In = OpenApiSecurityApiKeyLocation.Header
                });
                settings.OperationProcessors.Add(new OperationSecurityScopeProcessor("apiKey"));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
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
            app.UseApiKeyAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
