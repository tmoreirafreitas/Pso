using AutoMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Pso.Domain.Core;
using Pso.Domain.Core.Pipelines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using FluentValidation;
using Pso.Domain.Core.AutoMapper;
using Pso.Domain.Interfaces.Repositories;
using Pso.Domain.Interfaces.Services;

namespace Pso.Infra.CrossCutting.IoC.Extensions
{
    internal static class ServiceCollectionExtensions
    {
        private static readonly string Prefix = typeof(ServiceCollectionExtensions).Namespace?.Split('.')[0]; // Uppermost namespace
        private static readonly IEnumerable<Assembly> AllAssemblies;

        static ServiceCollectionExtensions()
        {
            AllAssemblies = AppDomain.CurrentDomain.GetAssemblies().Where(a => a.FullName.StartsWith(Prefix, StringComparison.OrdinalIgnoreCase));
        }

        public static void AddAutoMapperConfig(this IServiceCollection services)
        {
            services.AddAutoMapper(AllAssemblies);
            AutoMapperMediatRConfig.RegisterMappings();
        }

        public static void AddRepositoriesAndServices(this IServiceCollection services, ServiceLifetime lifetime = ServiceLifetime.Scoped)
        {
            var classesImplementingInterfaces = AllAssemblies.SelectMany(t =>
                    t.ExportedTypes.Select(y => y.GetTypeInfo()).Where(x =>
                        x.IsPublic
                        && !x.IsInterface
                        && !x.IsAbstract
                        && x.GetInterfaces().Any(i => i == typeof(IDomainRepository) || i == typeof(IDomainService))
                        ))
                .ToList();

            classesImplementingInterfaces.ForEach(assignedTypes =>
            {
                var allInterfaces = assignedTypes.ImplementedInterfaces
                    .Where(x => x != typeof(IDomainRepository) && x != typeof(IDomainService))
                    .Select(i => i.GetTypeInfo());

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

        public static void ConfigureMediatR(this IServiceCollection services, string projectName = "")
        {
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(MeasureTime<,>));
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(FailFastValidateCommand<,>));
            Assembly assembly;
            if (!string.IsNullOrEmpty(projectName) || !string.IsNullOrWhiteSpace(projectName))
            {
                assembly = Assembly.Load(projectName);
            }
            else
            {
                assembly = typeof(ICommand).GetTypeInfo().Assembly;
            }
            AssemblyScanner
                .FindValidatorsInAssembly(assembly)
                .ForEach(result => services.AddScoped(result.InterfaceType, result.ValidatorType));
            services.AddMediatR(assembly);
        }
    }
}