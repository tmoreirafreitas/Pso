using PSO.BackEnd.Domain.Validators;

namespace PSO.BackEnd.Domain.Entities
{
    public class Contato : Entity
    {
        public long ContatoId { get; private set; }
        public string Nome { get; private set; }
        public string Telefone { get; private set; }
        public string Email { get; private set; }
        public long ClienteId { get; private set; }
        public Cliente Cliente { get; private set; }

        public Contato(long contatoId, string nome, string telefone, string email, Cliente cliente)
        {
            ContatoId = contatoId;
            Nome = nome;
            Telefone = telefone;
            Email = email;
            ClienteId = cliente != null ? cliente.ClienteId : 0;
            Cliente = cliente;
            Validate(this, new ContatoValidator());
        }
    }
}
