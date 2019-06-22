using Pso.BackEnd.Command.Request.Generic;
using PSO.BackEnd.Domain.Entities;

namespace Pso.BackEnd.Command.Request.RequestPedido
{
    public class DeletePedidoCommand : DeleteCommand<Pedido>
    {
        public DeletePedidoCommand(long id, Pedido item) : base(id, item)
        {
        }
    }
}
