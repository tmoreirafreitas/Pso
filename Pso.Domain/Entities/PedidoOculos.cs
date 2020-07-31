namespace Pso.Domain.Entities
{
    public class PedidoOculos : Entity
    {
        public long PedidoId { get; private set; }
        public Pedido Pedido { get; set; }

        public long OculosId { get; private set; }
        public Oculos Oculos { get; set; }

        public PedidoOculos(long pedidoId, long oculosId)
        {
            PedidoId = pedidoId;
            OculosId = oculosId;
        }
    }
}
