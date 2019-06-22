using Pso.BackEnd.Command.Request.Generic;
using PSO.BackEnd.Domain.Entities;

namespace Pso.BackEnd.Command.Request.RequestOculos
{
    public class DeleteOculosCommand : DeleteCommand<Oculos>
    {
        public DeleteOculosCommand(long id, Oculos item) : base(id, item)
        {
        }
    }
}
