using System.Reflection;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Pso.Infra.CrossCutting.Filters;
using Pso.Infra.CrossCutting.IoC.Extensions;

namespace Pso.Infra.CrossCutting.IoC
{
    public class McvInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapperConfig();
            services.ConfigureMediatR();

            services.AddControllers(options =>
            {
                options.Filters.Add<NotificationFilter>();
                options.Filters.Add<UnitOfWorkFilter>();
            }).AddNewtonsoftJson(options =>
            {
                options.UseMemberCasing();
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                options.SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Local;
            }).AddFluentValidation(opt =>
            {
                opt.RegisterValidatorsFromAssembly(Assembly.GetCallingAssembly());
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "Portal de Serviço de Ótica Api", Version = "v1"});
            });
        }
    }
}