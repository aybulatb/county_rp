using CountyRP.ApiGateways.AdminPanel.API.Filters;
using CountyRP.ApiGateways.AdminPanel.Infrastructure.RestClient.ServiceGame;
using CountyRP.ApiGateways.AdminPanel.Infrastructure.RestClient.ServiceSite;
using CountyRP.ApiGateways.AdminPanel.Infrastructure.RestClients.ServiceForum;
using CountyRP.ApiGateways.AdminPanel.Infrastructure.RestClients.ServiceLogs;
using CountyRP.ApiGateways.AdminPanel.Infrastructure.Services;
using CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Forum.Implementations;
using CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Forum.Interfaces;
using CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Game.Implementations;
using CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Game.Interfaces;
using CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Interfaces;
using CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Logs.Implementations;
using CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Logs.Interfaces;
using CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Site.Implementations;
using CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Site.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Net.Http;

namespace CountyRP.ApiGateways.AdminPanel.API
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
            var httpClient2 = new HttpClient();
            httpClient2.DefaultRequestHeaders.Add("Authorization", "Bearer YW365he43w@t3");

            services.AddSingleton(new Infrastructure.RestClient.ServiceSite.UserClient(httpClient2)
            {
                BaseUrl = "https://localhost:10501"
            });

            services.AddSingleton(new SupportRequestMessageClient(httpClient2)
            {
                BaseUrl = "https://localhost:10501"
            });

            services.AddSingleton(new GroupClient(httpClient2)
            {
                BaseUrl = "https://localhost:10501"
            });

            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            var httpClient = new HttpClient(clientHandler);
            httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer strj654wtq12");

            services.AddSingleton(new PlayerClient(httpClient)
            {
                BaseUrl = "https://localhost:10531"
            });

            services.AddSingleton(new PersonClient(httpClient)
            {
                BaseUrl = "https://localhost:10531"
            });

            services.AddSingleton(new PlayerWithPersonsClient(httpClient)
            {
                BaseUrl = "https://localhost:10531"
            });

            HttpClientHandler clientHandler3 = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            var httpClient3 = new HttpClient(clientHandler3);
            httpClient3.DefaultRequestHeaders.Add("Authorization", "Bearer J%hw4y246tTWG");

            services.AddSingleton<IForumClient>(new ForumClient(httpClient3)
            {
                BaseUrl = "https://localhost:10511"
            });

            services.AddSingleton<IModeratorClient>(new ModeratorClient(httpClient3)
            {
                BaseUrl = "https://localhost:10511"
            });

            services.AddSingleton<IUserClient>(new Infrastructure.RestClients.ServiceForum.UserClient(httpClient3)
            {
                BaseUrl = "https://localhost:10511"
            });

            HttpClientHandler clientHandler4 = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            var httpClient4 = new HttpClient(clientHandler4);
            httpClient4.DefaultRequestHeaders.Add("Authorization", "Bearer esg443ytGSR3!t3");

            services.AddSingleton<ILogUnitClient>(new LogUnitClient(httpClient4)
            {
                BaseUrl = "https://localhost:10521"
            });

            services.AddTransient<ISiteService, SiteService>();
            services.AddTransient<IGameService, GameService>();
            services.AddTransient<IForumService, ForumService>();
            services.AddTransient<ILogsService, LogsService>();
            services.AddTransient<ISupportRequestMessageSiteService, SupportRequestMessageSiteService>();

            services.AddControllers(options =>
            {
                options.Filters.Add(typeof(CustomExceptionFilter));
            });

            services.AddSwaggerDocument(document =>
            {
                document.Title = "County RP AdminPanel Gateway API";
                document.Version = "v1";
                document.Description = "The County RP AdminPanel Gateway API documentation description.";
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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
