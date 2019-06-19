using PSO.BackEnd.Domain.Entities;

namespace Pso.BackEnd.Command.Request
{
    public class CreateClienteCommand : CreateCommand<Cliente>
    {
        public CreateClienteCommand(Cliente item) : base(item)
        {
        }
    }
}
