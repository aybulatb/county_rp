using CountyRP.Gateways.AdminPanel.Infrastructure.RestClient.ServiceSite;
using CountyRP.Gateways.AdminPanel.Infrastructure.Services;
using CountyRP.Gateways.AdminPanel.Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CountyRP.Gateways.AdminPanel.API
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
            HttpClient httpClient = new HttpClient();
            services.AddSingleton(new SupportRequestMessageClient(httpClient)
            {
                BaseUrl = "https://localhost:10501"
            });

            services.AddTransient<ISupportRequestMessageSiteService, SupportRequestMessageSiteService>();

            services.AddControllers();

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
