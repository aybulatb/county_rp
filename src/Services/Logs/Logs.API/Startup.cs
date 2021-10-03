using CountyRP.Services.Logs.API.Extensions;
using CountyRP.Services.Logs.API.Settings;
using CountyRP.Services.Logs.Infrastructure.DbContexts;
using CountyRP.Services.Logs.Infrastructure.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NSwag;
using NSwag.Generation.Processors.Security;
using System.Collections.Generic;

namespace Logs
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<LogsDbContext>(options => options.UseSqlServer(connectionString));

            services.AddTransient<ILogsRepository, LogsRepository>();

            var apiKeys = Configuration
                .GetSection("ApiKeys")
                .Get<IEnumerable<ApiKeySettings>>();

            services.AddSingleton(apiKeys);

            services.AddControllers();
            services.AddSwaggerDocument(settings =>
            {
                settings.Title = "County RP Logs Service API";
                settings.Version = "v1";
                settings.Description = "The County RP Logs Service API documentation description.";
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

            app.UseOpenApi();
            app.UseSwaggerUi3();

            app.UseRouting();

            app.UseAuthorization();
            app.UseApiKeyAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
