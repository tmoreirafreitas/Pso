using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Pso.BackEnd.Infra.Data.EFCore.Mappings;
using System.IO;

namespace Pso.BackEnd.Infra.Data.EFCore.Context
{
    public class PsoDbContext : DbContext
    {
        public PsoDbContext()
        {
            Database.EnsureCreated();
        }

        public PsoDbContext(DbContextOptions<PsoDbContext> options) : base(options)
        {
            Database.EnsureCreated();   // Create the database
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("public");
            modelBuilder.ApplyConfiguration(new ClienteMap());
            modelBuilder.ApplyConfiguration(new ContatoMap());
            modelBuilder.ApplyConfiguration(new EnderecoMap());
            modelBuilder.ApplyConfiguration(new FaturaMap());
            modelBuilder.ApplyConfiguration(new LenteMap());
            modelBuilder.ApplyConfiguration(new OculosMap());
            modelBuilder.ApplyConfiguration(new ParcelaMap());
            modelBuilder.ApplyConfiguration(new PedidoMap());
            modelBuilder.ApplyConfiguration(new PedidoOculosMap());
            base.OnModelCreating(modelBuilder);
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
