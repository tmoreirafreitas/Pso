using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pso.Domain.Interfaces.Repositories.UnitOfWork;
using Pso.Infra.CrossCutting.Filters;
using Pso.Infra.CrossCutting.IoC.Extensions;
using Pso.Infra.Data.EfCore.UnitOfWork;

namespace Pso.Infra.CrossCutting.IoC
{
    public class RepositoryAndServiceInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            #region Context
            // ASP.NET HttpContext dependency
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            //Instance Context            
            services.AddScoped<NotificationContext>();
            services.AddRepositoriesAndServices();
            #endregion
        }
    }
}