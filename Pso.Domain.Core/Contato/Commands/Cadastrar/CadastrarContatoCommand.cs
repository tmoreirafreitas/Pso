using Pso.Domain.Core.Validators;

namespace Pso.Domain.Core.Contato.Commands.Cadastrar
{
    public class CadastrarContatoCommand : Command<Entities.Contato>
    {
        public string Nome { get; private set; }
        public string Telefone { get; private set; }
        public string Email { get; private set; }

        public CadastrarContatoCommand(string nome, string telefone, string email)
        {
            Nome = nome;
            Telefone = telefone;
            Email = email;
            Validate(this, new CadastrarContatoCommandValidator());
        }
    }
}