using System.Net.Http;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using CountyRP.WebSite.Services;
using CountyRP.WebSite.Services.Interfaces;
using CountyRP.Extra;

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
                    options.ExpireTimeSpan = System.TimeSpan.FromDays(365);
                });

            HttpClient httpClient = new HttpClient();
            services.AddSingleton(new PlayerClient(httpClient));
            services.AddSingleton(new PersonClient(httpClient));
            services.AddSingleton(new AllPlayerClient(httpClient));
            services.AddSingleton(new PlayerAuthorizationClient(httpClient));
            services.AddSingleton(new PlayerRegistrationClient(httpClient));

            services.AddTransient<IPlayerAdapter, PlayerAdapter>();
            services.AddTransient<IPersonAdapter, PersonAdapter>();
            services.AddTransient<IAllPlayerAdapter, AllPlayerAdapter>();
            services.AddTransient<IPlayerAuthorizationAdapter, PlayerAuthorizationAdapter>();
            services.AddTransient<IPlayerRegistrationAdapter, PlayerRegistrationAdapter>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
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

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "api/{controller}/{action=Index}/{id?}");
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
