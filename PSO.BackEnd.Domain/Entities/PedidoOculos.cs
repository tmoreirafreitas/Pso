namespace PSO.BackEnd.Domain.Entities
{
    public class PedidoOculos : Entity
    {
        public long PedidoId { get; set; }
        public Pedido Pedido { get; set; }

        public long OculosId { get; set; }
        public Oculos Oculos { get; set; }

        public PedidoOculos(Pedido pedido, Oculos oculos)
        {
            PedidoId = pedido != null ? pedido.PedidoId : 0;
            Pedido = pedido;
            OculosId = oculos != null ? oculos.OculosId : 0;
            Oculos = oculos;
        }
    }
}
