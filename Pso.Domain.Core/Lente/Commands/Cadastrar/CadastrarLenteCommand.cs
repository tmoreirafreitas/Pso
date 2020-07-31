using Pso.Domain.Core.Oculos.Commands.Cadastrar;
using Pso.Domain.Core.Validators;
using Pso.Domain.Enum;

namespace Pso.Domain.Core.Lente.Commands.Cadastrar
{
    public class CadastrarLenteCommand : Command<Entities.Lente>
    {
        public float Grau { get; private set; }
        public float Cyl { get; private set; }
        public byte Eixo { get; private set; }
        public LenteType LenteType { get; private set; }
        public long OculosId { get; private set; }
        public CadastrarOculosCommand Oculos { get; set; }

        public CadastrarLenteCommand(float grau, float cyl, byte eixo, LenteType lenteType, long oculosId)
        {
            Grau = grau;
            Cyl = cyl;
            Eixo = eixo;
            LenteType = lenteType;
            OculosId = oculosId;
            Validate(this, new CadastrarLenteCommandValidator());
        }
    }
}