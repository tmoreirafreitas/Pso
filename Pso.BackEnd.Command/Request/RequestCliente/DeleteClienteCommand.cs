using Pso.BackEnd.Command.Request.Generic;
using PSO.BackEnd.Domain.Entities;

namespace Pso.BackEnd.Command.Request.RequestCliente
{
    public class DeleteClienteCommand : DeleteCommand<Cliente>
    {
        public DeleteClienteCommand(long id, Cliente item) : base(id, item)
        {
        }
    }
}
