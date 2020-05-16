using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;

using CountyRP.WebAPI.Models;

namespace CountyRP.WebAPI
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
            services.AddControllers();

            string connectionString = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<PlayerContext>(options => options.UseMySql(connectionString));
            services.AddDbContext<FactionContext>(options => options.UseMySql(connectionString));
            services.AddDbContext<GangContext>(options => options.UseMySql(connectionString));
            services.AddDbContext<PropertyContext>(options => options.UseMySql(connectionString));
            services.AddDbContext<GroupContext>(options => options.UseMySql(connectionString));
            services.AddDbContext<AdminLevelContext>(options => options.UseMySql(connectionString));

            // Register the Swagger services
            services.AddSwaggerDocument();
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
            if (!env.IsDevelopment())
                app.UseOpenApi(configure =>
                {
                    configure.PostProcess = (document, _) =>
                    {
                        document.Info.Title = "County RP Service";
                        //document.Schemes = new[] { NSwag.OpenApiSchema.Https };
                        document.Info.Description = "Общий сервис со всеми основными ресурсами";
                    };
                });
            else
                app.UseOpenApi(configure =>
                {
                    configure.PostProcess = (document, _) =>
                    {
                        document.Info.Title = "County RP Service";
                        document.Info.Description = "Общий сервис со всеми основными ресурсами";
                    };
                });
            app.UseSwaggerUi3();

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
