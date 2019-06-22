using Pso.BackEnd.Command.Request.Generic;
using PSO.BackEnd.Domain.Entities;

namespace Pso.BackEnd.Command.Request.RequestOculos
{
    public class UpdateOculosCommand : UpdateCommand<Oculos>
    {
        public UpdateOculosCommand(long id, Oculos item) : base(id, item)
        {
        }
    }
}
