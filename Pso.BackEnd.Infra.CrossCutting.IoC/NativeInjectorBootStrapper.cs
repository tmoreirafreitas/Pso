using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
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
            services.AddScoped<IRequestHandler<CreateClienteCommand, bool>, CreateClienteCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateClienteCommand, bool>, UpdateClienteCommandHandler>();
            services.AddScoped<IRequestHandler<DeleteClienteCommand, bool>, DeleteClienteCommandHandler>();

            //Endereco Request
            services.AddScoped<IRequestHandler<CreateEnderecoCommand, bool>, CreateEnderecoCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateEnderecoCommand, bool>, UpdateEnderecoCommandHandler>();
            services.AddScoped<IRequestHandler<DeleteEnderecoCommand, bool>, DeleteEnderecoCommandHandler>();

            //Contato Request
            services.AddScoped<IRequestHandler<CreateContatoCommand, bool>, CreateContatoCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateContatoCommand, bool>, UpdateContatoCommandHandler>();
            services.AddScoped<IRequestHandler<DeleteContatoCommand, bool>, DeleteContatoCommandHandler>();

            //Contato Fatura
            services.AddScoped<IRequestHandler<CreateFaturaCommand, bool>, CreateFaturaCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateFaturaCommand, bool>, UpdateFaturaCommandHandler>();
            services.AddScoped<IRequestHandler<DeleteFaturaCommand, bool>, DeleteFaturaCommandHandler>();

            //Contato Lente
            services.AddScoped<IRequestHandler<CreateLenteCommand, bool>, CreateLenteCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateLenteCommand, bool>, UpdateLenteCommandHandler>();
            services.AddScoped<IRequestHandler<DeleteLenteCommand, bool>, DeleteLenteCommandHandler>();

            //Contato Oculos
            services.AddScoped<IRequestHandler<CreateOculosCommand, bool>, CreateOculosCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateOculosCommand, bool>, UpdateOculosCommandHandler>();
            services.AddScoped<IRequestHandler<DeleteOculosCommand, bool>, DeleteOculosCommandHandler>();

            //Contato Parcela
            services.AddScoped<IRequestHandler<CreateParcelaCommand, bool>, CreateParcelaCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateParcelaCommand, bool>, UpdateParcelaCommandHandler>();
            services.AddScoped<IRequestHandler<DeleteParcelaCommand, bool>, DeleteParcelaCommandHandler>();

            //Contato Pedido
            services.AddScoped<IRequestHandler<CreatePedidoCommand, bool>, CreatePedidoCommandHandler>();
            services.AddScoped<IRequestHandler<UpdatePedidoCommand, bool>, UpdatePedidoCommandHandler>();
            services.AddScoped<IRequestHandler<DeletePedidoCommand, bool>, DeletePedidoCommandHandler>();

            //Contato PedidoOculos
            services.AddScoped<IRequestHandler<CreatePedidoOculosCommand, bool>, CreatePedidoOculosCommandHandler>();
            services.AddScoped<IRequestHandler<UpdatePedidoOculosCommand, bool>, UpdatePedidoOculosCommandHandler>();
            services.AddScoped<IRequestHandler<DeletePedidoOculosCommand, bool>, DeletePedidoOculosCommandHandler>();

            #endregion

            #region Entity Framework Repository
            // Infra-Data UnitOfWork dependency
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // Infra-Data WriteEfRepository dependency
            services.AddScoped(typeof(IWriteEfRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(IWriteMongoRepository<>), typeof(MongoRepository<>));
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
            services.AddScoped(typeof(IReadMongoRepository<>), typeof(MongoRepository<>));            
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
            #endregion
        }
    }
}