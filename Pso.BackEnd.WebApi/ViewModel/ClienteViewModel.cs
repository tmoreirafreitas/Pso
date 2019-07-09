using PSO.BackEnd.Domain.Enum;
using System;
using System.Collections.Generic;

namespace Pso.BackEnd.WebApi.ViewModel
{
    public class ClienteViewModel: EntityBaseViewModel
    {
        public string Nome { get; set; }
        public string Rg { get; set; }
        public string Cpf { get; set; }
        public string Filiacao { get; set; }
        public bool? IsSPC { get; set; }
        public DateTime Nascimento { get; set; }
        public SexoType Sexo { get; set; }
        public EnderecoViewModel Endereco { get; set; }
        public ICollection<ContatoViewModel> Contatos { get; set; }
    }
}
