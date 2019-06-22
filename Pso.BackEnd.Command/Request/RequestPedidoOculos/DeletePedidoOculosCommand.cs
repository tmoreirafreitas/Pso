using Pso.BackEnd.Command.Request.Generic;
using PSO.BackEnd.Domain.Entities;

namespace Pso.BackEnd.Command.Request.RequestPedidoOculos
{
    public class DeletePedidoOculosCommand : DeleteCommand<PedidoOculos>
    {
        public DeletePedidoOculosCommand(long id, PedidoOculos item) : base(id, item)
        {
        }
    }
}
