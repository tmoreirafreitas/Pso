using System;
using System.Collections.Generic;
using Pso.Domain.Enum;

namespace Pso.Api.InputModel
{
    public class ClienteInputModel
    {
        public string Nome { get; set; }
        public string Rg { get; set; }
        public string Cpf { get; set; }
        public string Filiacao { get; set; }
        public bool IsSPC { get; set; }
        public DateTime Nascimento { get; set; }
        public SexoType Sexo { get; set; }
        public EnderecoInputModel Endereco { get; set; }
        public ICollection<ContatoInputModel> Contatos { get; set; }
    }
}
