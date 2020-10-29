using System.Net.Http;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using NSwag.Generation.Processors.Security;

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

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidIssuer = AuthOptions.ISSUER,

                        ValidateAudience = false,

                        ValidateLifetime = true,

                        IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
                        ValidateIssuerSigningKey = true,
                    };
                }
            );

            var apiKey = Configuration.GetValue<string>("CommonWebAPIKey");

            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("api-key", apiKey);
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
            // Register the Swagger services
            services.AddSwaggerDocument(document =>
            {
                document.Title = "Sample API";
                document.Version = "v1";
                document.Description = "The sample API documentation description.";
                document.DocumentProcessors.Add(new SecurityDefinitionAppender("JWT token", new NSwag.OpenApiSecurityScheme
                {
                    Type = NSwag.OpenApiSecuritySchemeType.ApiKey,
                    Name = "Authorization",
                    In = NSwag.OpenApiSecurityApiKeyLocation.Header,
                    Description = "Copy 'Bearer ' + valid JWT token into field"
                }));
                document.OperationProcessors.Add(new OperationSecurityScopeProcessor("JWT token"));
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
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            //app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseRouting();

            if (env.IsStaging() || env.IsDevelopment())
            {
                // Подключаем CORS
                app.UseCors(builder => builder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            }

            // Register the Swagger generator and the Swagger UI middlewares
            app.UseOpenApi();
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
