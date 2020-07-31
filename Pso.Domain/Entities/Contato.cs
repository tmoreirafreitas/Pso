using Pso.Domain.Validators;

namespace Pso.Domain.Entities
{
    public class Contato : Entity
    {
        public string Nome { get; private set; }
        public string Telefone { get; private set; }
        public string Email { get; private set; }
        public long ClienteId { get; private set; }
        public Cliente Cliente { get; set; }

        public Contato(string nome, string telefone, string email, long clienteId = 0)
        {
            Nome = nome;
            Telefone = telefone;
            Email = email;
            ClienteId = clienteId;
            Validate(this, new ContatoValidator());
        }
    }
}
