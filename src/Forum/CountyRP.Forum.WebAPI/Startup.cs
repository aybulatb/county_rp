using System.Net.Http;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;

using CountyRP.Forum.Domain.Interfaces;
using CountyRP.Forum.Infrastructure;
using CountyRP.Forum.Infrastructure.Models;
using CountyRP.Extra;
using CountyRP.Forum.WebAPI.Services.Interfaces;
using CountyRP.Forum.WebAPI.Services;

namespace CountyRP.Forum.WebAPI
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
            services.AddControllers();

            string connectionString = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<ForumContext>(options => options.UseMySql(connectionString));
            services.AddDbContext<TopicContext>(options => options.UseMySql(connectionString));
            services.AddDbContext<PostContext>(options => options.UseMySql(connectionString));
            services.AddDbContext<ModeratorContext>(options => options.UseMySql(connectionString));

            services.AddTransient<IForumRepository, ForumRepository>();
            services.AddTransient<ITopicRepository, TopicRepository>();
            services.AddTransient<IPostRepository, PostRepository>();
            services.AddTransient<IModeratorRepository, ModeratorRepository>();
            services.AddTransient<IForumService, ForumService>();
            services.AddTransient<ITopicService, TopicService>();
            services.AddTransient<IModeratorService, ModeratorService>();
            services.AddTransient<IPostService, PostService>();

            HttpClient httpClient = new HttpClient();
            services.AddSingleton(new PlayerClient(httpClient));
            services.AddSingleton(new GroupClient(httpClient));

            // Register the Swagger services
            services.AddSwaggerDocument();
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

            if (!env.IsDevelopment())
                app.UseOpenApi(configure =>
                {
                    configure.PostProcess = (document, _) =>
                    {
                        document.Info.Title = "County RP Forum";
                        //document.Schemes = new[] { NSwag.OpenApiSchema.Https };
                        document.Info.Description = "Сервис с ресурсами форума";
                    };
                });
            else
                app.UseOpenApi(configure =>
                {
                    configure.PostProcess = (document, _) =>
                    {
                        document.Info.Title = "County RP Forum";
                        document.Info.Description = "Сервис с ресурсами форума";
                    };
                });
            app.UseSwaggerUi3();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action}/{id?}");
            });
        }
    }
}
