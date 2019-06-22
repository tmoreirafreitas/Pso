using Pso.BackEnd.Command.Request.Generic;
using PSO.BackEnd.Domain.Entities;

namespace Pso.BackEnd.Command.Request.RequestOculos
{
    public class CreateOculosCommand : CreateCommand<Oculos>
    {
        public CreateOculosCommand(Oculos item) : base(item)
        {
        }
    }
}
