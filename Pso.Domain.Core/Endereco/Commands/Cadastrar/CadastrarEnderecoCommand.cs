using Pso.Domain.Core.Cliente.Commands.Cadastrar;
using Pso.Domain.Core.Validators;

namespace Pso.Domain.Core.Endereco.Commands.Cadastrar
{
    public class CadastrarEnderecoCommand : Command<Entities.Endereco>
    {
        public string Cep { get; private set; }
        public string Logradouro { get; private set; }
        public string Bairro { get; private set; }
        public string Cidade { get; private set; }
        public string Estado { get; private set; }
        public int? Numero { get; private set; }
        public string Complemento { get; private set; }
        public CadastrarClienteCommand Cliente { get; set; }

        public CadastrarEnderecoCommand(string logradouro, string bairro, string cidade, string estado, int? numero, string cep, string complemento)
        {
            Logradouro = logradouro;
            Bairro = bairro;
            Cidade = cidade;
            Estado = estado;
            Numero = numero;
            Complemento = complemento;
            Cep = cep;
        }
    }
}