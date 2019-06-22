using Pso.BackEnd.Command.Request.Generic;
using PSO.BackEnd.Domain.Entities;

namespace Pso.BackEnd.Command.Request.RequestPedido
{
    public class UpdatePedidoCommand : UpdateCommand<Pedido>
    {
        public UpdatePedidoCommand(long id, Pedido item) : base(id, item)
        {
        }
    }
}
