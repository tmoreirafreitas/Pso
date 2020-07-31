using System.Collections.Generic;

namespace Pso.Api.InputModel
{
    public class OculosInputModel
    {
        public ICollection<LenteInputModel> Lentes { get; set; }
        public string Cor { get; set; }
        public float DP { get; set; }
        public float ALT { get; set; }
        public ICollection<PedidoOculosInputModel> PedidosOculos { get; set; }
    }
}
