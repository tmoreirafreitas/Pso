using Pso.BackEnd.Command.Request.Generic;
using PSO.BackEnd.Domain.Entities;

namespace Pso.BackEnd.Command.Request.RequestPedido
{
    public class CreatePedidoCommand : CreateCommand<Pedido>
    {
        public CreatePedidoCommand(Pedido item) : base(item)
        {
        }
    }
}
