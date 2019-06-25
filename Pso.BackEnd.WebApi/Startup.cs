using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Pso.BackEnd.Infra.CrossCutting.IoC;
using Pso.BackEnd.Infra.CrossCutting.NotificationsAndFilters;
using Pso.BackEnd.Infra.Data.EFCore.Context;
using Pso.BackEnd.Infra.Data.NoSQLMdb;
using Pso.BackEnd.WebApi.AutoMapper;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Reflection;

namespace Pso.BackEnd.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            #region Add CORS  
            services.AddCors(options => options.AddPolicy("Cors", builder =>
            {
                builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
            }));
            #endregion         

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            // Registering Mappings automatically only works if the 
            // Automapper Profile classes are in ASP.NET project
            AutoMapperConfig.RegisterMappings();

            services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());

            // Config Entity Framework
            string migrationsAssembly = typeof(Startup).GetTypeInfo().Assembly.GetName().Name; //"Sgot.Infra.Data";//typeof(Startup).GetTypeInfo().Assembly.GetName().Name;
            services.AddEntityFrameworkNpgsql()
                .AddDbContext<PsoDbContext>(options =>
                options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"),
                b => b.MigrationsAssembly(migrationsAssembly)));

            services.AddMvc(options =>
            {
                options.Filters.Add<NotificationFilter>();
            })
            .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
            .AddJsonOptions(options => options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Portal de Serviço de Ótica Api", Version = "v1" });
            });

            // Configure MongoDb
            services.Configure<PsoDbMongoDatabaseSettings>(
                    Configuration.GetSection(nameof(PsoDbMongoDatabaseSettings)));

            // .NET Native DI Abstraction
            RegisterServices(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            loggerFactory.AddLog4Net("log4net.config");
            app.UseHttpsRedirection();

            app.UseCors("Cors");
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Portal de Serviço de Ótica Api V1");
            });
            app.UseMvc();
        }

        private static void RegisterServices(IServiceCollection services)
        {            
            // Adding dependencies from another layers (isolated from Presentation)
            NativeInjectorBootStrapper.RegisterServices(services);
        }
    }
}
