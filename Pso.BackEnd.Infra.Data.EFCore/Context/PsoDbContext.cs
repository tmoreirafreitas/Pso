using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Pso.BackEnd.Infra.Data.EFCore.Context
{
    public sealed class PsoDbContext : DbContext
    {
        public PsoDbContext()
        {
            // Create the database
            //Database.Migrate();
        }

        public PsoDbContext(DbContextOptions<PsoDbContext> options) : base(options)
        {
            // Create the database
            //Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Ignore<ValidationFailure>();
            modelBuilder.Ignore<ValidationResult>();
            ApplyAllConfiguration(modelBuilder, typeof(PsoDbContext).Assembly);
        }

        private void ApplyAllConfiguration(ModelBuilder modelBuilder, Assembly assembly)
        {
            var mappingTypes = assembly
                .GetTypes()
                .Where(x =>
                    !x.IsAbstract
                    && x.GetInterfaces()
                        .Any(y =>
                            y.GetTypeInfo().IsGenericType
                            && y.GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<>)));

            var entityMethod = typeof(ModelBuilder).GetMethods()
                .Single(x => x.Name == "Entity" &&
                             x.IsGenericMethod &&
                             x.ReturnType.Name == "EntityTypeBuilder`1");

            foreach (var mappingType in mappingTypes)
            {
                var genericTypeArg = mappingType.GetInterfaces().Single().GenericTypeArguments.Single();
                var genericEntityMethod = entityMethod.MakeGenericMethod(genericTypeArg);
                var entityBuilder = genericEntityMethod.Invoke(modelBuilder, null);
                var mapper = Activator.CreateInstance(mappingType);
                mapper.GetType().GetMethod("Configure")?.Invoke(mapper, new[] { entityBuilder });
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // get the configuration from the app settings
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            // define the database to use
            optionsBuilder
                .UseNpgsql(config.GetConnectionString("DefaultConnection"));
        }
    }
}
