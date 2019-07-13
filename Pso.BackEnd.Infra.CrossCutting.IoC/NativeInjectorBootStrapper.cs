using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Pso.BackEnd.Command.Handles;
using Pso.BackEnd.Command.Handles.HandlerCliente;
using Pso.BackEnd.Command.Handles.HandlerContato;
using Pso.BackEnd.Command.Handles.HandlerEndereco;
using Pso.BackEnd.Command.Handles.HandlerFatura;
using Pso.BackEnd.Command.Handles.HandlerLente;
using Pso.BackEnd.Command.Handles.HandlerOculos;
using Pso.BackEnd.Command.Handles.HandlerParcela;
using Pso.BackEnd.Command.Handles.HandlerPedido;
using Pso.BackEnd.Command.Handles.HandlerPedidoOculos;
using Pso.BackEnd.Command.Request.RequestCliente;
using Pso.BackEnd.Command.Request.RequestContato;
using Pso.BackEnd.Command.Request.RequestEndereco;
using Pso.BackEnd.Command.Request.RequestFatura;
using Pso.BackEnd.Command.Request.RequestLente;
using Pso.BackEnd.Command.Request.RequestOculos;
using Pso.BackEnd.Command.Request.RequestParcela;
using Pso.BackEnd.Command.Request.RequestPedido;
using Pso.BackEnd.Command.Request.RequestPedidoOculos;
using Pso.BackEnd.Infra.CrossCutting.NotificationsAndFilters;
using Pso.BackEnd.Infra.Data.EFCore.Context;
using Pso.BackEnd.Infra.Data.EFCore.Repositories;
using Pso.BackEnd.Infra.Data.EFCore.UnitOfWork;
using Pso.BackEnd.Infra.Data.NoSQLMdb;
using PSO.BackEnd.Domain.Entities;
using PSO.BackEnd.Domain.Interfaces.Repositories.Ef.Read;
using PSO.BackEnd.Domain.Interfaces.Repositories.Ef.Write;
using PSO.BackEnd.Domain.Interfaces.Repositories.NoSQLMdb;
using PSO.BackEnd.Domain.Interfaces.Repositories.NoSQLMdb.Read;
using PSO.BackEnd.Domain.Interfaces.Repositories.NoSQLMdb.Write;
using PSO.BackEnd.Domain.Interfaces.Repositories.UnitOfWork;

namespace Pso.BackEnd.Infra.CrossCutting.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            #region Mediator Write Dependency
            //Services Core dependency
            services.AddScoped<IMediator, Mediator>();

            //Cliente Request
            services.AddTransient<IRequestHandler<CreateClienteCommand, bool>, CreateClienteCommandHandler>();
            services.AddTransient<IRequestHandler<UpdateClienteCommand, bool>, UpdateClienteCommandHandler>();
            services.AddTransient<IRequestHandler<DeleteClienteCommand, bool>, DeleteClienteCommandHandler>();

            //Endereco Request
            services.AddTransient<IRequestHandler<CreateEnderecoCommand, bool>, CreateEnderecoCommandHandler>();
            services.AddTransient<IRequestHandler<UpdateEnderecoCommand, bool>, UpdateEnderecoCommandHandler>();
            services.AddTransient<IRequestHandler<DeleteEnderecoCommand, bool>, DeleteEnderecoCommandHandler>();

            //Contato Request
            services.AddTransient<IRequestHandler<CreateContatoCommand, bool>, CreateContatoCommandHandler>();
            services.AddTransient<IRequestHandler<UpdateContatoCommand, bool>, UpdateContatoCommandHandler>();
            services.AddTransient<IRequestHandler<DeleteContatoCommand, bool>, DeleteContatoCommandHandler>();

            //Contato Fatura
            services.AddTransient<IRequestHandler<CreateFaturaCommand, bool>, CreateFaturaCommandHandler>();
            services.AddTransient<IRequestHandler<UpdateFaturaCommand, bool>, UpdateFaturaCommandHandler>();
            services.AddTransient<IRequestHandler<DeleteFaturaCommand, bool>, DeleteFaturaCommandHandler>();

            //Contato Lente
            services.AddTransient<IRequestHandler<CreateLenteCommand, bool>, CreateLenteCommandHandler>();
            services.AddTransient<IRequestHandler<UpdateLenteCommand, bool>, UpdateLenteCommandHandler>();
            services.AddTransient<IRequestHandler<DeleteLenteCommand, bool>, DeleteLenteCommandHandler>();

            //Contato Oculos
            services.AddTransient<IRequestHandler<CreateOculosCommand, bool>, CreateOculosCommandHandler>();
            services.AddTransient<IRequestHandler<UpdateOculosCommand, bool>, UpdateOculosCommandHandler>();
            services.AddTransient<IRequestHandler<DeleteOculosCommand, bool>, DeleteOculosCommandHandler>();

            //Contato Parcela
            services.AddTransient<IRequestHandler<CreateParcelaCommand, bool>, CreateParcelaCommandHandler>();
            services.AddTransient<IRequestHandler<UpdateParcelaCommand, bool>, UpdateParcelaCommandHandler>();
            services.AddTransient<IRequestHandler<DeleteParcelaCommand, bool>, DeleteParcelaCommandHandler>();

            //Contato Pedido
            services.AddTransient<IRequestHandler<CreatePedidoCommand, bool>, CreatePedidoCommandHandler>();
            services.AddTransient<IRequestHandler<UpdatePedidoCommand, bool>, UpdatePedidoCommandHandler>();
            services.AddTransient<IRequestHandler<DeletePedidoCommand, bool>, DeletePedidoCommandHandler>();

            //Contato PedidoOculos
            services.AddTransient<IRequestHandler<CreatePedidoOculosCommand, bool>, CreatePedidoOculosCommandHandler>();
            services.AddTransient<IRequestHandler<UpdatePedidoOculosCommand, bool>, UpdatePedidoOculosCommandHandler>();
            services.AddTransient<IRequestHandler<DeletePedidoOculosCommand, bool>, DeletePedidoOculosCommandHandler>();

            // Notifications
            services.AddTransient<INotificationHandler<CreateClienteCommand>, CreatedNotificationHandler<Cliente>>();
            services.AddTransient<INotificationHandler<DeleteClienteCommand>, DeletedNotificationHandler<Cliente>>();
            services.AddTransient<INotificationHandler<UpdateClienteCommand>, UpdatedNotificationHandler<Cliente>>();

            services.AddTransient<INotificationHandler<CreateEnderecoCommand>, EnderecoCreatedNotificationHandler>();
            services.AddTransient<INotificationHandler<DeleteEnderecoCommand>, EnderecoDeletedNotificationHandler>();
            services.AddTransient<INotificationHandler<UpdateEnderecoCommand>, EnderecoUpdatedNotificationHandler>();

            services.AddTransient<INotificationHandler<CreateContatoCommand>, ContatoCreatedNotificationHandler>();
            services.AddTransient<INotificationHandler<DeleteContatoCommand>, ContatoDeletedNotificationHandler>();
            services.AddTransient<INotificationHandler<UpdateContatoCommand>, ContatoUpdatedNotificationHandler>();

            services.AddTransient<INotificationHandler<CreateFaturaCommand>, FaturaCreatedNotificationHandler>();
            services.AddTransient<INotificationHandler<DeleteFaturaCommand>, FaturaDeletedNotificationHandler>();
            services.AddTransient<INotificationHandler<UpdateFaturaCommand>, FaturaUpdatedNotificationHandler>();

            services.AddTransient<INotificationHandler<CreateLenteCommand>, CreatedNotificationHandler<Lente>>();
            services.AddTransient<INotificationHandler<DeleteLenteCommand>, DeletedNotificationHandler<Lente>>();
            services.AddTransient<INotificationHandler<UpdateLenteCommand>, UpdatedNotificationHandler<Lente>>();

            services.AddTransient<INotificationHandler<CreateOculosCommand>, CreatedNotificationHandler<Oculos>>();
            services.AddTransient<INotificationHandler<DeleteOculosCommand>, DeletedNotificationHandler<Oculos>>();
            services.AddTransient<INotificationHandler<UpdateOculosCommand>, UpdatedNotificationHandler<Oculos>>();

            services.AddTransient<INotificationHandler<CreateParcelaCommand>, ParcelaCreatedNotificationHandler>();
            services.AddTransient<INotificationHandler<DeleteParcelaCommand>, ParcelaDeletedNotificationHandler>();
            services.AddTransient<INotificationHandler<UpdateParcelaCommand>, ParcelaUpdatedNotificationHandler>();

            services.AddTransient<INotificationHandler<CreatePedidoCommand>, CreatedNotificationHandler<Pedido>>();
            services.AddTransient<INotificationHandler<DeletePedidoCommand>, DeletedNotificationHandler<Pedido>>();
            services.AddTransient<INotificationHandler<UpdatePedidoCommand>, UpdatedNotificationHandler<Pedido>>();

            services.AddTransient<INotificationHandler<CreatePedidoOculosCommand>, CreatedNotificationHandler<PedidoOculos>>();
            services.AddTransient<INotificationHandler<DeletePedidoOculosCommand>, DeletedNotificationHandler<PedidoOculos>>();
            services.AddTransient<INotificationHandler<UpdatePedidoOculosCommand>, UpdatedNotificationHandler<PedidoOculos>>();
            

            #endregion

            #region Entity Framework Repository
            // Infra-Data UnitOfWork dependency
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // Infra-Data WriteEfRepository dependency
            services.AddScoped(typeof(IWriteEfRepository<>), typeof(Repository<>));
            services.AddScoped<IClienteWriteEfRepository, ClienteEfRepository>();
            services.AddScoped<IContatoWriteEfRepository, ContatoEfRepository>();
            services.AddScoped<IEnderecoWriteEfRepository, EnderecoEfRepository>();
            services.AddScoped<IFaturaWriteEfRepository, FaturaEfRepository>();
            services.AddScoped<ILenteWriteEfRepository, LenteEfRepository>();
            services.AddScoped<IOculosWriteEfRepository, OculosEfRepository>();
            services.AddScoped<IParcelaWriteEfRepository, ParcelaEfRepository>();
            services.AddScoped<IPedidoWriteEfRepository, PedidoEfRepository>();
            services.AddScoped<IPedidoOculosWriteEfRepository, PedidoOculosEfRepository>();

            // Infra-Data ReadeEfRepository dependency            
            services.AddScoped(typeof(IReadEfRepository<>), typeof(Repository<>));
            services.AddScoped<IClienteReadEfRepository, ClienteEfRepository>();
            services.AddScoped<IContatoReadEfRepository, ContatoEfRepository>();
            services.AddScoped<IEnderecoReadEfRepository, EnderecoEfRepository>();
            services.AddScoped<IFaturaReadEfRepository, FaturaEfRepository>();
            services.AddScoped<ILenteReadEfRepository, LenteEfRepository>();
            services.AddScoped<IOculosReadEfRepository, OculosEfRepository>();
            services.AddScoped<IParcelaReadEfRepository, ParcelaEfRepository>();
            services.AddScoped<IPedidoReadEfRepository, PedidoEfRepository>();
            services.AddScoped<IPedidoOculosReadEfRepository, PedidoOculosEfRepository>();
            #endregion

            #region MongoDb Repository          
            // Infra-Data WriteMongoDbRepository dependency
            services.AddScoped<IClienteWriteMongoRepository, ClienteMongoRepository>();
            services.AddScoped<IContatoWriteMongoRepository, ContatoMongoRepository>();
            services.AddScoped<IEnderecoWriteMongoRepository, EnderecoMongoRepository>();
            services.AddScoped<IFaturaWriteMongoRepository, FaturaMongoRepository>();
            services.AddScoped<ILenteWriteMongoRepository, LenteMongoRepository>();
            services.AddScoped<IOculosWriteMongoRepository, OculosMongoRepository>();
            services.AddScoped<IParcelaWriteMongoRepository, ParcelaMongoRepository>();
            services.AddScoped<IPedidoWriteMongoRepository, PedidoMongoRepository>();
            services.AddScoped<IPedidoOculosWriteMongoRepository, PedidoOculosMongoRepository>();

            // Infra-Data ReadeMongoRepository dependency
            services.AddScoped<IClienteReadMongoRepository, ClienteMongoRepository>();
            services.AddScoped<IContatoReadMongoRepository, ContatoMongoRepository>();
            services.AddScoped<IEnderecoReadMongoRepository, EnderecoMongoRepository>();
            services.AddScoped<IFaturaReadMongoRepository, FaturaMongoRepository>();
            services.AddScoped<ILenteReadMongoRepository, LenteMongoRepository>();
            services.AddScoped<IOculosReadMongoRepository, OculosMongoRepository>();
            services.AddScoped<IParcelaReadMongoRepository, ParcelaMongoRepository>();
            services.AddScoped<IPedidoReadMongoRepository, PedidoMongoRepository>();
            services.AddScoped<IPedidoOculosReadMongoRepository, PedidoOculosMongoRepository>();
            #endregion

            #region Context
            // ASP.NET HttpContext dependency
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            //Instance Context            
            services.AddScoped<NotificationContext>();
            services.AddScoped<DbContext, PsoDbContext>();
            services.AddScoped<PsoDbContext>();
            services.AddScoped<MongoDataContext>();
            services.AddScoped(typeof(IReadMongoRepository<>), typeof(MongoRepository<>));
            services.AddScoped(typeof(IWriteMongoRepository<>), typeof(MongoRepository<>));
            #endregion
        }
    }
}