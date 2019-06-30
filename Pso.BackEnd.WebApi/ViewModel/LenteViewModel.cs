using PSO.BackEnd.Domain.Enum;

namespace Pso.BackEnd.WebApi.ViewModel
{
    public class LenteViewModel
    {
        public float Grau { get; set; }
        public float Cyl { get; set; }
        public byte Eixo { get; set; }
        public LenteType LenteType { get; set; }
        public long OculosId { get; set; }
        public OculosViewModel Oculos { get; set; }
    }
}
