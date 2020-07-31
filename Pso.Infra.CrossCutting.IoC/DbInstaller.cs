using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pso.Infra.Data.EfCore.Context;
using Pso.Infra.Data.NoSqlMongoDb.Mapping;
using Pso.Infra.Data.NoSqlMongoDb.Repositories;

namespace Pso.Infra.CrossCutting.IoC
{
    public class DbInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            // Config Entity Framework
            string migrationsAssembly = "Pso.Infra.Data.EfCore";
            services.AddDbContext<PsoDbContext>((sp, options) =>
                    options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"),
                        b => b.MigrationsAssembly(migrationsAssembly)));

            services.Configure<PsoDbMongoDatabaseSettings>(configuration.GetSection("MongoConnection"));
            services.AddScoped<DbContext, PsoDbContext>();
            services.AddScoped<PsoDbContext>();
            services.AddScoped<MongoDataContext>();

            //Configure MongoDb
            MongoDbPersistence.Configure();
        }
    }
}
