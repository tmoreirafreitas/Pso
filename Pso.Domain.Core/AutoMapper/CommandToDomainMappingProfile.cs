using AutoMapper;
using Pso.Domain.Core.Cliente.Commands.Cadastrar;
using Pso.Domain.Core.Contato.Commands.Cadastrar;
using Pso.Domain.Core.Endereco.Commands.Cadastrar;
using Pso.Domain.Core.Pedido.Commands.Cadastrar;

namespace Pso.Domain.Core.AutoMapper
{
    public class CommandToDomainMappingProfile : Profile
    {
        public CommandToDomainMappingProfile()
        {
            CreateMap<CadastrarClienteCommand, Entities.Cliente>();
            CreateMap<CadastrarContatoCommand, Entities.Contato>();
            CreateMap<CadastrarEnderecoCommand, Entities.Endereco>();
            //CreateMap<CreateOrUpdateFaturaCommand, Fatura>();
            //CreateMap<CreateOrUpdateLenteCommand, Lente>();
            //CreateMap<CreateOrUpdateOculosCommand, Oculos>();
            //CreateMap<CreateOrUpdateParcelaCommand, Parcela>();
            CreateMap<CadastrarPedidoCommand, Entities.Pedido>();
        }
    }
}
