using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NJsonSchema;
using NSwag.AspNetCore;
using NSwag.SwaggerGeneration.Processors;
using System.Linq;

namespace NSwag_WebApi_Example
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddSwagger();
            services.AddApiVersioning(o => o.ApiVersionReader = new QueryStringApiVersionReader());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseSwaggerWithApiExplorer(config =>
            {
                config.GeneratorSettings.DefaultPropertyNameHandling =
                    PropertyNameHandling.CamelCase;
                config.GeneratorSettings.OperationProcessors.TryGet<ApiVersionProcessor>()
                    .IncludedVersions = new[] { "1" };
                config.SwaggerRoute = "swagger/v1/swagger.json";
                config.PostProcess = document =>
                {
                    document.Info.Version = "v1.0.0";
                    document.Info.Title = "NSwag WebAPI Example";
                    document.Info.Description = "Testing the limitations of nswag.";
                    document.Tags = document.Tags.OrderBy(n => n.Name).ToList();
                };
                config.GeneratorSettings.SchemaType = SchemaType.OpenApi3;
            });

            app.UseSwaggerUi3(config =>
            {
                config.SwaggerRoutes.Add(new SwaggerUi3Route("v1", "/swagger/v1/swagger.json"));
            });

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
