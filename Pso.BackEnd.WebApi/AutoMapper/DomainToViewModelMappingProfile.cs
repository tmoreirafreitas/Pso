using AutoMapper;
using Pso.BackEnd.WebApi.ViewModel;
using PSO.BackEnd.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pso.BackEnd.WebApi.AutoMapper
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
            CreateMap<PedidoOculos, PedidoOculosViewModel>();
        }
    }
}
