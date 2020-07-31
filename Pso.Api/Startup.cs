using System.Globalization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Pso.Api.AutoMapper;
using Pso.Infra.CrossCutting.Filters;
using Pso.Infra.CrossCutting.IoC.Extensions;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace Pso.Api
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
            CultureInfo.CurrentCulture = new CultureInfo("pt-BR");
            services.AddResponseCompression(options =>
            {
                options.Providers.Add<GzipCompressionProvider>();
            });
            services.InstallServicesInAssembly(Configuration);
            AutoMapperConfig.RegisterMappings();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddLog4Net("log4net.config");
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseStatusCodePages();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.RoutePrefix = "swagger";
                c.SwaggerEndpoint("v1/swagger.json", "Portal de Serviço de Ótica Api V1");
                c.DocumentTitle = " PORTAL DE SERVIÇOS Documentation";
                c.DocExpansion(DocExpansion.None);
            });

            app.UseMiddleware(typeof(RequestMiddliware));
            app.UseResponseCompression();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
