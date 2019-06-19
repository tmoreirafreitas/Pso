using PSO.BackEnd.Domain.Entities;

namespace Pso.BackEnd.Command.Request
{
    public class UpdateClienteCommand : UpdateCommand<Cliente>
    {
        public UpdateClienteCommand(long id, Cliente item) : base(id, item)
        {
        }
    }
}
