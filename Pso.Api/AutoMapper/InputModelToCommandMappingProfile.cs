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
    public class InputModelToCommandMappingProfile : Profile
    {
        public InputModelToCommandMappingProfile()
        {
            CreateMap<ClienteInputModel, CadastrarClienteCommand>();
            CreateMap<ContatoInputModel, CadastrarContatoCommand>();
            CreateMap<EnderecoInputModel, CadastrarEnderecoCommand>();
            CreateMap<FaturaInputModel, CadastrarFaturaCommand>();
            CreateMap<LenteInputModel, CadastrarLenteCommand>();
            CreateMap<OculosInputModel, CadastrarOculosCommand>();
            CreateMap<ParcelaInputModel, CadastrarParcelaCommand>();
            CreateMap<PedidoInputModel, CadastrarPedidoCommand>();
        }
    }
}
