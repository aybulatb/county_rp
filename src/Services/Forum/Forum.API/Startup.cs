using CountyRP.BuildingBlocks.ApiKeyAuthenticationMiddleware;
using CountyRP.Services.Forum.Infrastructure.DbContexts;
using CountyRP.Services.Forum.Infrastructure.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NSwag;
using NSwag.Generation.Processors.Security;
using System.Collections.Generic;

namespace CountyRP.Services.Forum.API
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<ForumDbContext>(options => options.UseSqlServer(connectionString));

            services.AddTransient<IForumRepository, ForumRepository>();

            var apiKeys = Configuration
                .GetSection("ApiKeys")
                .Get<IEnumerable<ApiKeySettings>>();

            services.AddSingleton(apiKeys);

            services.AddControllers();

            services.AddSwaggerDocument(settings =>
            {
                settings.Title = "County RP Forum Service API";
                settings.Version = "v1";
                settings.Description = "The County RP Forum Service API documentation description.";
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
