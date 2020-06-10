using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System.Linq;
using System.Reflection;

namespace Pso.BackEnd.Infra.CrossCutting.IoC
{
    public sealed class MediatRInstaller : InstallerBase, IInstaller
    {
        public MediatRInstaller()
        {
            LoadAssemblies();
        }

        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            #region Mediator Write Dependency
            services.AddMediatR(AllAssemblies.ToArray());
            services.AddScoped<IMediator, Mediator>();
            AddMediatorCommandHandlers(services);
            AddMediatorNotificationHandlers(services);
            #endregion
        }

        private void AddMediatorCommandHandlers(IServiceCollection services, ServiceLifetime lifetime = ServiceLifetime.Transient)
        {
            var requests = AllAssemblies.SelectMany(t =>
                t.ExportedTypes.Select(y => y.GetTypeInfo()).Where(x =>
                    !x.IsInterface
                    && !x.IsAbstract
                    && x.IsPublic
                    && x.GetInterfaces().Any(i =>
                        i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IRequest<>)))).ToList();

            var handlerCommands = AllAssemblies.SelectMany(t =>
                    t.ExportedTypes.Select(y => y.GetTypeInfo()).Where(x =>
                        x.IsPublic
                        && !x.IsInterface
                        && !x.IsAbstract
                        && !x.IsGenericType
                        && x.GetInterfaces().Any(i =>
                            i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IRequestHandler<>)
                            || i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IRequestHandler<,>))))
                .ToList();

            requests.ForEach(request =>
            {
                var resultType = request.ImplementedInterfaces.Select(i => i.GetTypeInfo())
                                                        .Single(t =>
                                                            t.IsGenericType
                                                            && t.GetGenericTypeDefinition() == typeof(IRequest<>)
                                                            && t.GetGenericArguments().Any())
                                                        .GetGenericArguments()
                                                        .First();

                var handlerTypeInterface = resultType == typeof(Unit)
                    ? typeof(IRequestHandler<>).MakeGenericType(request)
                    : typeof(IRequestHandler<,>).MakeGenericType(request, resultType);

                var handlerCommand = handlerCommands.SingleOrDefault(t =>
                {
                    var memberInfo = handlerTypeInterface.GetGenericArguments()[0].BaseType;
                    return memberInfo != null && (t.ImplementedInterfaces != null &&
                                                  t.ImplementedInterfaces.FirstOrDefault()?.GetGenericArguments()[0]
                                                      .FullName == memberInfo.FullName);
                });

                if (handlerCommand != null)
                    services.TryAdd(new ServiceDescriptor(handlerTypeInterface, handlerCommand, lifetime));
            });
        }
        private void AddMediatorNotificationHandlers(IServiceCollection services, ServiceLifetime lifetime = ServiceLifetime.Transient)
        {
            var notifications = AllAssemblies.SelectMany(t =>
                    t.ExportedTypes.Select(y => y.GetTypeInfo()).Where(x =>
                        !x.IsInterface
                        && !x.IsAbstract
                        && x.IsPublic
                        && x.GetInterfaces().Any(i => !i.IsGenericType && i == typeof(INotification))))
                .ToList();

            var handlerNotifications = AllAssemblies.SelectMany(t =>
                    t.ExportedTypes.Select(y => y.GetTypeInfo()).Where(x =>
                        x.IsPublic
                        && !x.IsInterface
                        && !x.IsAbstract
                        && !x.IsGenericType
                        && x.GetInterfaces().Any(i =>
                            i.IsGenericType && i.GetGenericTypeDefinition() == typeof(INotificationHandler<>))))
                .ToList();

            notifications.ForEach(notification =>
            {
                var handlerTypeInterface = typeof(INotificationHandler<>).MakeGenericType(notification);
                var handlerCommand = handlerNotifications.SingleOrDefault(t =>
                {
                    var memberInfo = handlerTypeInterface.GetGenericArguments()[0].BaseType;
                    return memberInfo != null &&
                           t.ImplementedInterfaces.First().GetGenericArguments()[0].FullName == memberInfo.FullName;
                });

                if (handlerCommand != null)
                    services.TryAdd(new ServiceDescriptor(handlerTypeInterface, handlerCommand, lifetime));
            });
        }
    }
}