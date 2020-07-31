using Pso.Domain.Validators;

namespace Pso.Domain.Entities
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
        public long ClienteId { get; private set; }
        public Cliente Cliente { get; set; }

        public Endereco(string logradouro, string bairro, string cidade, string estado, int? numero, string cep, string complemento, long clienteId = 0)
        {
            Logradouro = logradouro;
            Bairro = bairro;
            Cidade = cidade;
            Estado = estado;
            Numero = numero;
            Complemento = complemento;
            Cep = cep;
            ClienteId = clienteId;
            Validate(this, new EnderecoValidator());
        }
    }
}
