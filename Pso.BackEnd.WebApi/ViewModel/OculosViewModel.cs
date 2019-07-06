using System;
using System.Collections.Generic;

namespace Pso.BackEnd.WebApi.ViewModel
{
    public class OculosViewModel : EntityBaseViewModel
    {
        public ICollection<LenteViewModel> Lentes { get; set; }
        public string Cor { get; set; }
        public float DP { get; set; }
        public float ALT { get; set; }
        public long PedidoOculosId { get; set; }
        public ICollection<PedidoOculosViewModel> PedidosOculos { get; set; }
    }
}
