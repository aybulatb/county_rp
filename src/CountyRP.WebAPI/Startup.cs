using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using NSwag.Generation.Processors.Security;

using CountyRP.WebAPI.DbContexts;
using CountyRP.WebAPI.Extensions;

namespace CountyRP.WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public List<string> APIKeys { get; set; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddNewtonsoftJson();

            string connectionString = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<PlayerContext>(options => options.UseSqlServer(connectionString));
            services.AddDbContext<FactionContext>(options => options.UseSqlServer(connectionString));
            services.AddDbContext<GangContext>(options => options.UseSqlServer(connectionString));
            services.AddDbContext<PropertyContext>(options => options.UseSqlServer(connectionString));
            services.AddDbContext<GroupContext>(options => options.UseSqlServer(connectionString));
            services.AddDbContext<AdminLevelContext>(options => options.UseSqlServer(connectionString));
            services.AddDbContext<BanContext>(options => options.UseSqlServer(connectionString));
            services.AddDbContext<LogContext>(options => options.UseSqlServer(connectionString));
            services.AddDbContext<AppearanceContext>(options => options.UseSqlServer(connectionString));
            services.AddDbContext<InventoryContext>(options => options.UseSqlServer(connectionString));
            services.AddDbContext<BlackMarketContext>(options => options.UseSqlServer(connectionString));

            APIKeys = new List<string>();
            APIKeys.Add(Configuration.GetSection("AllowedServices:0:APIKey").Value);
            APIKeys.Add(Configuration.GetSection("AllowedServices:1:APIKey").Value);
            APIKeys.Add(Configuration.GetSection("AllowedServices:2:APIKey").Value);

            // Register the Swagger services
            services.AddSwaggerDocument(document =>
            {
                document.Title = "Sample API";
                document.Version = "v1";
                document.Description = "The sample API documentation description.";
                document.DocumentProcessors.Add(new SecurityDefinitionAppender("APIKey", new NSwag.OpenApiSecurityScheme
                {
                    Type = NSwag.OpenApiSecuritySchemeType.ApiKey,
                    Name = "api-key",
                    In = NSwag.OpenApiSecurityApiKeyLocation.Header,
                    Description = "APIKey"
                }));
                document.OperationProcessors.Add(new OperationSecurityScopeProcessor("APIKey"));
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseHttpsRedirection();

            app.UseRouting();

            // Register the Swagger generator and the Swagger UI middlewares
            app.UseOpenApi();
            app.UseSwaggerUi3();

            app.UseAPIKeys(APIKeys);

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "api/{controller}/{action}/{id?}");
            });
        }
    }
}
