using Pso.Domain.Core.Oculos.Commands.Cadastrar;
using Pso.Domain.Entities;

namespace Pso.Domain.Core.Pedido.Commands.Cadastrar
{
    public class CadastrarPedidoOculosCommand : Command<PedidoOculos>
    {
        public long PedidoId { get; }
        public CadastrarPedidoCommand Pedido { get; set; }

        public long OculosId { get; }
        public CadastrarOculosCommand Oculos { get; set; }

        public CadastrarPedidoOculosCommand(long pedidoId, long oculosId)
        {
            PedidoId = pedidoId;
            OculosId = oculosId;
        }
    }
}