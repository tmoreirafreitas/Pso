using Pso.BackEnd.Command.Request.Generic;
using PSO.BackEnd.Domain.Entities;

namespace Pso.BackEnd.Command.Request.RequestCliente
{
    public class CreateClienteCommand : CreateCommand<Cliente>
    {
        public CreateClienteCommand(Cliente item) : base(item)
        {
        }
    }
}
