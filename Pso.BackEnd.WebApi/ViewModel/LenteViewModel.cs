using PSO.BackEnd.Domain.Enum;
using System;

namespace Pso.BackEnd.WebApi.ViewModel
{
    public class LenteViewModel : EntityBaseViewModel
    {
        public float Grau { get; set; }
        public float Cyl { get; set; }
        public byte Eixo { get; set; }
        public LenteType LenteType { get; set; }
        public long OculosId { get; set; }
        public OculosViewModel Oculos { get; set; }
    }
}
