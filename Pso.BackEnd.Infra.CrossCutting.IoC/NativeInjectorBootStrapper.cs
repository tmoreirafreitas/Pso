using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Pso.BackEnd.Command.Handles.HandlerCliente;
using Pso.BackEnd.Command.Handles.HandlerEndereco;
using Pso.BackEnd.Command.Request.RequestCliente;
using Pso.BackEnd.Command.Request.RequestEndereco;
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
            services.AddScoped<DbContext, PsoDbContext>();
            services.AddScoped<PsoDbContext>();
        }
    }
}
