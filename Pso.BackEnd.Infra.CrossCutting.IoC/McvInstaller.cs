using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Pso.BackEnd.Infra.CrossCutting.NotificationsAndFilters;
using Swashbuckle.AspNetCore.Swagger;

namespace Pso.BackEnd.Infra.CrossCutting.IoC
{
    public class McvInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Portal de Serviço de Ótica Api", Version = "v1" });
            });

            services.AddMvc(options =>
                {
                    options.Filters.Add<NotificationFilter>();
                    options.Filters.Add<UnitOfWorkFilter>();
                })
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                .AddJsonOptions(options => options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);
        }
    }
}