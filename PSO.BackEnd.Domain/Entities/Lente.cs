using PSO.BackEnd.Domain.Enum;
using PSO.BackEnd.Domain.Validators;
using System;

namespace PSO.BackEnd.Domain.Entities
{
    public class Lente : Entity
    {
        public float Grau { get; private set; }
        public float Cyl { get; private set; }
        public byte Eixo { get; private set; }
        public LenteType LenteType { get; private set; }
        public long OculosId { get; private set; }
        public Oculos Oculos { get; set; }

        public Lente(float grau, float cyl, byte eixo, LenteType lenteType, long oculosId)
        {
            Grau = grau;
            Cyl = cyl;
            Eixo = eixo;
            LenteType = lenteType;
            OculosId = oculosId;
            Validate(this, new LenteValidator());
        }
    }
}
