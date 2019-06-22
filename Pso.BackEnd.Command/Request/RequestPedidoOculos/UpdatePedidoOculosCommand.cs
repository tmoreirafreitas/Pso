using Pso.BackEnd.Command.Request.Generic;
using PSO.BackEnd.Domain.Entities;

namespace Pso.BackEnd.Command.Request.RequestPedidoOculos
{
    public class UpdatePedidoOculosCommand : UpdateCommand<PedidoOculos>
    {
        public UpdatePedidoOculosCommand(long id, PedidoOculos item) : base(id, item)
        {
        }
    }
}
