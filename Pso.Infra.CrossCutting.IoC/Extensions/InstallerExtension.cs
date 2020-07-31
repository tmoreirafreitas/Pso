using System;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Pso.Infra.CrossCutting.IoC.Extensions
{
    public static class InstallerExtension
    {
        public static void InstallServicesInAssembly(this IServiceCollection services, IConfiguration configuration)
        {
            var classesImplementingInstallers = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(t => 
                    t.ExportedTypes.Where(x =>
                        typeof(IInstaller).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract)
                .Select(Activator.CreateInstance).Cast<IInstaller>())
                .ToList();
            classesImplementingInstallers.ForEach(installer => installer.InstallServices(services, configuration));
        }
    }
}