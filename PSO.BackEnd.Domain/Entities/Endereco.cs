using PSO.BackEnd.Domain.Validators;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace PSO.BackEnd.Domain.Entities
{
    public class Endereco : Entity
    {
        public string Cep { get; private set; }
        public string Logradouro { get; private set; }
        public string Bairro { get; private set; }
        public string Cidade { get; private set; }
        public string Estado { get; private set; }
        public int? Numero { get; private set; }
        public string Complemento { get; private set; }        
        public IEnumerable<Cliente> Clientes { get; set; }

        public Endereco(string logradouro, string bairro, string cidade, string estado, int? numero, string cep, string complemento)
        {
            Logradouro = logradouro;
            Bairro = bairro;
            Cidade = cidade;
            Estado = estado;
            Numero = numero;
            Complemento = complemento;
            Cep = cep;
            Clientes = new List<Cliente>();
            Validate(this, new EnderecoValidator());
        }
    }
}
