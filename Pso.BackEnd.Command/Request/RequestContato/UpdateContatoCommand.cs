using Pso.BackEnd.Command.Request.Generic;
using PSO.BackEnd.Domain.Entities;

namespace Pso.BackEnd.Command.Request.RequestContato
{
    public class UpdateContatoCommand : UpdateCommand<Contato>
    {
        public UpdateContatoCommand(long id, Contato item) : base(id, item)
        {
        }
    }
}
