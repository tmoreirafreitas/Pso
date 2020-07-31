using AutoMapper;
using Pso.Domain.Core.Cliente.Commands.Cadastrar;
using Pso.Domain.Core.Contato.Commands.Cadastrar;
using Pso.Domain.Core.Endereco.Commands.Cadastrar;
using Pso.Domain.Core.Pedido.Commands.Cadastrar;

namespace Pso.Domain.Core.AutoMapper
{
    public class DomainToCommandMappingProfile : Profile
    {
        public DomainToCommandMappingProfile()
        {
            CreateMap<Entities.Cliente, CadastrarClienteCommand>();
            CreateMap<Entities.Contato, CadastrarContatoCommand>();
            CreateMap<Entities.Endereco, CadastrarEnderecoCommand>();
            //CreateMap<Fatura, CreateOrUpdateFaturaCommand>();
            //CreateMap<Lente, CreateOrUpdateLenteCommand>();
            //CreateMap<Oculos, CreateOrUpdateOculosCommand>();
            //CreateMap<Parcela, CreateOrUpdateParcelaCommand>();
            CreateMap<Entities.Pedido, CadastrarPedidoCommand>();
        }
    }
}
