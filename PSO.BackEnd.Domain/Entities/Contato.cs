using PSO.BackEnd.Domain.Validators;

namespace PSO.BackEnd.Domain.Entities
{
    public class Contato : Entity
    {
        public string Nome { get; private set; }
        public string Telefone { get; private set; }
        public string Email { get; private set; }
        public long ClienteId { get; private set; }
        public Cliente Cliente { get; private set; }

        public Contato(string nome, string telefone, string email, Cliente cliente)
        {
            Nome = nome;
            Telefone = telefone;
            Email = email;
            ClienteId = cliente != null ? cliente.Id : 0;
            Cliente = cliente;
            Validate(this, new ContatoValidator());
        }
    }
}
