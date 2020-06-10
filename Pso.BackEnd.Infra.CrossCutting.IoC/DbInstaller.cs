using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pso.BackEnd.Infra.Data.EFCore.Context;
using Pso.BackEnd.Infra.Data.NoSQLMdb;
using Pso.BackEnd.Infra.Data.NoSQLMdb.Mapping;

namespace Pso.BackEnd.Infra.CrossCutting.IoC
{
    public sealed class DbInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            // Config Entity Framework
            string migrationsAssembly = "Pso.BackEnd.Infra.Data.EFCore";
            services.AddEntityFrameworkNpgsql()
                .AddDbContext<PsoDbContext>(options =>
                    options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"),
                        b => b.MigrationsAssembly(migrationsAssembly)));

            services.Configure<PsoDbMongoDatabaseSettings>(configuration.GetSection("MongoConnection"));

            //Configure MongoDb
            MongoDbPersistence.Configure();
        }
    }
}
