using Pso.BackEnd.Command.Request.Generic;
using PSO.BackEnd.Domain.Entities;

namespace Pso.BackEnd.Command.Request.RequestPedidoOculos
{
    public class CreatePedidoOculosCommand : CreateCommand<PedidoOculos>
    {
        public CreatePedidoOculosCommand(PedidoOculos item) : base(item)
        {
        }
    }
}
