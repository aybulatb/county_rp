using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using CountyRP.Extra;
using CountyRP.WebSite.Services;
using CountyRP.WebSite.Services.Interfaces;

namespace CountyRP.WebSite
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
            services.AddControllersWithViews();

            // In production, the React files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/build";
            });

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.Events.OnRedirectToLogin = async (context) =>
                    {
                        context.Response.StatusCode = 401;
                        await Task.CompletedTask;
                    };
                    options.Events.OnRedirectToAccessDenied = async (context) =>
                    {
                        context.Response.StatusCode = 403;
                        await Task.CompletedTask;
                    };
                    options.ExpireTimeSpan = System.TimeSpan.FromDays(365);
                }
            );

            HttpClient httpClient = new HttpClient();
            services.AddSingleton(new PlayerClient(httpClient));
            services.AddSingleton(new PersonClient(httpClient));
            services.AddSingleton(new AllPlayerClient(httpClient));
            services.AddSingleton(new FactionClient(httpClient));
            services.AddSingleton(new GroupClient(httpClient));
            services.AddSingleton(new AdminLevelClient(httpClient));
            services.AddSingleton(new LogClient(httpClient));
            services.AddSingleton(new SiteBanClient(httpClient));
            services.AddSingleton(new GameBanClient(httpClient));

            services.AddTransient<IPlayerAdapter, PlayerAdapter>();
            services.AddTransient<IPersonAdapter, PersonAdapter>();
            services.AddTransient<IAllPlayerAdapter, AllPlayerAdapter>();
            services.AddTransient<IFactionAdapter, FactionAdapter>();
            services.AddTransient<IGroupAdapter, GroupAdapter>();
            services.AddTransient<IAdminLevelAdapter, AdminLevelAdapter>();
            services.AddTransient<ILogAdapter, LogAdapter>();
            services.AddTransient<ISiteBanAdapter, SiteBanAdapter>();
            services.AddTransient<IGameBanAdapter, GameBanAdapter>();

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
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            if (env.IsStaging())
            {
                // Подключаем CORS
                app.UseCors(builder => builder.AllowAnyOrigin());
            }

            //app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseRouting();

            // Register the Swagger generator and the Swagger UI middlewares
            if (!env.IsDevelopment())
                app.UseOpenApi(configure =>
                {
                    configure.PostProcess = (document, _) =>
                    {
                        document.Info.Title = "County RP Site";
                        document.Schemes = new[] { NSwag.OpenApiSchema.Https };
                        document.Info.Description = "API сайта для фронтенда";
                    };
                });
            else
                app.UseOpenApi(configure =>
                {
                    configure.PostProcess = (document, _) =>
                    {
                        document.Info.Title = "County RP Site";
                        document.Info.Description = "API сайта для фронтенда";
                    };
                });
            app.UseSwaggerUi3();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "api/{controller}/{action=Index}/{id?}");
                endpoints.MapControllerRoute(
                    name: "areas",
                    pattern: "api/{area:exists}/{controller}/{action}/{id?}");
            });

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseReactDevelopmentServer(npmScript: "start");
                }
            });
        }
    }
}
