using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Pso.Infra.CrossCutting.IoC
{
    internal interface IInstaller
    {
        void InstallServices(IServiceCollection services, IConfiguration configuration);
    }
}