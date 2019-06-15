using PSO.BackEnd.Domain.Enum;
using PSO.BackEnd.Domain.Validators;

namespace PSO.BackEnd.Domain.Entities
{
    public class Lente : Entity
    {
        public float Grau { get; private set; }
        public float Cyl { get; private set; }
        public byte Eixo { get; private set; }
        public LenteType LenteType { get; private set; }
        public Oculos Oculos { get; private set; }

        public Lente(float grau, float cyl, byte eixo, LenteType lenteType, Oculos oculos)
        {
            Grau = grau;
            Cyl = cyl;
            Eixo = eixo;
            LenteType = lenteType;
            Oculos = oculos;
            Validate(this, new LenteValidator());
        }
    }
}
