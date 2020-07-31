using AutoMapper;
using Pso.Api.ViewModel;
using Pso.Domain.Entities;

namespace Pso.Api.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Cliente, ClienteViewModel>();
            CreateMap<Contato, ContatoViewModel>();
            CreateMap<Endereco, EnderecoViewModel>();
            CreateMap<Fatura, FaturaViewModel>();
            CreateMap<Lente, LenteViewModel>();
            CreateMap<Oculos, OculosViewModel>();
            CreateMap<Parcela, ParcelaViewModel>();
            CreateMap<Pedido, PedidoViewModel>();
        }
    }
}
