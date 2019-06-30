using AutoMapper;
using Pso.BackEnd.WebApi.ViewModel;
using PSO.BackEnd.Domain.Entities;

namespace Pso.BackEnd.WebApi.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<ClienteViewModel, Cliente>();
            CreateMap<ContatoViewModel, Contato>();
            CreateMap<EnderecoViewModel, Endereco>();
            CreateMap<FaturaViewModel, Fatura>();
            CreateMap<LenteViewModel, Lente>();
            CreateMap<OculosViewModel, Oculos>();
            CreateMap<ParcelaViewModel, Parcela>();
            CreateMap<PedidoOculosViewModel, PedidoOculos>();
        }
    }
}
