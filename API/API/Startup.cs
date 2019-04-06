using API.Core.Automapper;
using API.Core.DAL;
using API.Core.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace API
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddAutoMapper(MapperConfig.Config);
            services.AddTransient<IDbContextFactory, DbContextFactory>();
            services.AddSingleton<UnitOfWork>();
            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "Test API",
                    Description = "ASP.NET Core Web API"
                });
                //c.CustomSchemaIds(r => r.FullName);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            //app.UseHttpsRedirection();
            app.UseMvc(RouteConfig.Configure);
            app.UseSwagger();
            app.UseSwaggerUI(c => {  
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API For CourseWork");
            });
            //app.UseMvc(routes =>
            //{
            //    routes.MapRoute(
            //              name: "default",
            //              template: "{controller=Home}/{action=Index}/{id?}");
            //    routes.MapSpaFallbackRoute(
            //              name: "Training project",
            //              defaults: new { controller = "Home", action = "Index" });
            //});
        }
    }
}
