using AutoMapper;
using Pso.Api.InputModel;
using Pso.Domain.Core.Cliente.Commands.Cadastrar;
using Pso.Domain.Core.Contato.Commands.Cadastrar;
using Pso.Domain.Core.Endereco.Commands.Cadastrar;
using Pso.Domain.Core.Fatura.Commands.Cadastrar;
using Pso.Domain.Core.Lente.Commands.Cadastrar;
using Pso.Domain.Core.Oculos.Commands.Cadastrar;
using Pso.Domain.Core.Parcela.Commands.Cadastrar;
using Pso.Domain.Core.Pedido.Commands.Cadastrar;

namespace Pso.Api.AutoMapper
{
    public class CommandToInputModelMappingProfile : Profile
    {
        public CommandToInputModelMappingProfile()
        {
            CreateMap<CadastrarClienteCommand, ClienteInputModel>();
            CreateMap<CadastrarContatoCommand, ContatoInputModel>();
            CreateMap<CadastrarEnderecoCommand, EnderecoInputModel>();
            CreateMap<CadastrarFaturaCommand, FaturaInputModel>();
            CreateMap<CadastrarLenteCommand, LenteInputModel>();
            CreateMap<CadastrarOculosCommand, OculosInputModel>();
            CreateMap<CadastrarParcelaCommand, ParcelaInputModel>();
            CreateMap<CadastrarPedidoCommand, PedidoInputModel>();
        }
    }
}
