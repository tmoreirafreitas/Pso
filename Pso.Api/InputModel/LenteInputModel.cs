using Pso.Domain.Enum;

namespace Pso.Api.InputModel
{
    public class LenteInputModel
    {
        public float Grau { get; set; }
        public float Cyl { get; set; }
        public byte Eixo { get; set; }
        public LenteType LenteType { get; set; }
        public OculosInputModel Oculos { get; set; }
    }
}
