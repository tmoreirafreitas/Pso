using Pso.Domain.Enum;

namespace Pso.Api.ViewModel
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