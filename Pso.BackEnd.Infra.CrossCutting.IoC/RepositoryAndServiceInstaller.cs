using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Pso.BackEnd.Infra.CrossCutting.NotificationsAndFilters;
using Pso.BackEnd.Infra.Data.EFCore.Context;
using Pso.BackEnd.Infra.Data.EFCore.UnitOfWork;
using Pso.BackEnd.Infra.Data.NoSQLMdb;
using PSO.BackEnd.Domain.Interfaces.Repositories.UnitOfWork;
using System.Linq;
using System.Reflection;

namespace Pso.BackEnd.Infra.CrossCutting.IoC
{
    public class RepositoryAndServiceInstaller : InstallerBase, IInstaller
    {
        public RepositoryAndServiceInstaller()
        {
            LoadAssemblies();
        }

        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            #region Context
            // ASP.NET HttpContext dependency
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            //Instance Context            
            services.AddScoped<NotificationContext>();
            services.AddScoped<DbContext, PsoDbContext>();
            services.AddScoped<PsoDbContext>();
            services.AddScoped<MongoDataContext>();
            RegisterAllTypes(services);
            #endregion
        }

        private void RegisterAllTypes(IServiceCollection services, ServiceLifetime lifetime = ServiceLifetime.Scoped)
        {
            var classesImplementingInterfaces = AllAssemblies.SelectMany(t =>
                    t.ExportedTypes.Select(y => y.GetTypeInfo()).Where(x =>
                        x.IsPublic
                        && !x.IsInterface
                        && !x.IsAbstract
                        && x.GetInterfaces().Any(i =>
                            i.Name.ToUpper().StartsWith("I") && (i.Name.ToUpper().EndsWith(@"REPOSITORY") || i.Name.ToUpper().EndsWith(@"REPOSITORY`1"))
                            || i.Name.ToUpper().StartsWith("I") && (i.Name.ToUpper().EndsWith(@"SERVICE") || i.Name.ToUpper().EndsWith(@"SERVICE`1"))
                        )))
                .ToList();

            classesImplementingInterfaces.ForEach(assignedTypes =>
            {
                var allInterfaces = assignedTypes.ImplementedInterfaces.Select(i => i.GetTypeInfo());
                foreach (var serviceType in allInterfaces)
                {
                    if (!assignedTypes.IsGenericType)
                    {
                        services.TryAdd(new ServiceDescriptor(serviceType, assignedTypes, lifetime));
                    }
                    else
                    {
                        var arguments = serviceType.GetGenericTypeDefinition().GetGenericArguments();
                        var combinedType = serviceType.GetGenericTypeDefinition().MakeGenericType(arguments);
                        services.TryAdd(new ServiceDescriptor(combinedType, assignedTypes, lifetime));
                    }
                }
            });
        }
    }
}