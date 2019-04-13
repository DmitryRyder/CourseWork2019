using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerUI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace API.Swagger
{
    public static class SwaggerServiceExtensions
    {
        public static IServiceCollection AddSwaggerDocumentation(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                    c.SwaggerDoc("v1", new Info
                    {
                        Version = "v1",
                        Title = "API",
                    });

                    //var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                    //var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                    //c.IncludeXmlComments(xmlPath);

                    //var security = new Dictionary<string, IEnumerable<string>>
                    //{
                    //    {"Bearer", new string[] { }},
                    //};

                    //c.AddSecurityDefinition("Bearer", new ApiKeyScheme
                    //{
                    //    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    //    Name = "Authorization",
                    //    In = "header",
                    //    Type = "apiKey"
                    //});
                    //c.AddSecurityRequirement(security);
                    c.DescribeAllEnumsAsStrings();
            });

            return services;
        }

        public static IApplicationBuilder UseSwaggerDocumentation(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API For CourseWork");
                c.DocumentTitle = "Учет электричества - API";
                c.DocExpansion(DocExpansion.None);
                c.RoutePrefix = string.Empty;
                c.EnableDeepLinking();
            });

            return app;
        }
    }
}
