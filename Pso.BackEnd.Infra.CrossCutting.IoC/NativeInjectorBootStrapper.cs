using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Pso.BackEnd.Command.Handles.HandlerCliente;
using Pso.BackEnd.Command.Handles.HandlerContato;
using Pso.BackEnd.Command.Handles.HandlerEndereco;
using Pso.BackEnd.Command.Handles.HandlerFatura;
using Pso.BackEnd.Command.Handles.HandlerLente;
using Pso.BackEnd.Command.Request.RequestCliente;
using Pso.BackEnd.Command.Request.RequestContato;
using Pso.BackEnd.Command.Request.RequestEndereco;
using Pso.BackEnd.Command.Request.RequestFatura;
using Pso.BackEnd.Command.Request.RequestLente;
using Pso.BackEnd.Infra.CrossCutting.NotificationsAndFilters;
using Pso.BackEnd.Infra.Data.EFCore.Context;
using Pso.BackEnd.Infra.Data.EFCore.Repositories;
using Pso.BackEnd.Infra.Data.EFCore.UnitOfWork;
using PSO.BackEnd.Domain.Interfaces.Repositories.Ef.Read;
using PSO.BackEnd.Domain.Interfaces.Repositories.Ef.Write;
using PSO.BackEnd.Domain.Interfaces.Repositories.UnitOfWork;

namespace Pso.BackEnd.Infra.CrossCutting.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // ASP.NET HttpContext dependency
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

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

            // Infra-Data UnitOfWork dependency
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // Infra-Data WriteEfRepository dependency
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
            services.AddScoped<IClienteReadEfRepository, ClienteEfRepository>();
            services.AddScoped<IContatoReadEfRepository, ContatoEfRepository>();
            services.AddScoped<IEnderecoReadEfRepository, EnderecoEfRepository>();
            services.AddScoped<IFaturaReadEfRepository, FaturaEfRepository>();
            services.AddScoped<ILenteReadEfRepository, LenteEfRepository>();
            services.AddScoped<IOculosReadEfRepository, OculosEfRepository>();
            services.AddScoped<IParcelaReadEfRepository, ParcelaEfRepository>();
            services.AddScoped<IPedidoReadEfRepository, PedidoEfRepository>();
            services.AddScoped<IPedidoOculosReadEfRepository, PedidoOculosEfRepository>();

            //Instance Context            
            services.AddScoped<NotificationContext>();
            services.AddScoped<DbContext, PsoDbContext>();
            services.AddScoped<PsoDbContext>();
        }
    }
}
