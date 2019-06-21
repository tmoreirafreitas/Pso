using Pso.BackEnd.Command.Request.Generic;
using PSO.BackEnd.Domain.Entities;

namespace Pso.BackEnd.Command.Request.RequestContato
{
    public class DeleteContatoCommand : DeleteCommand<Contato>
    {
        public DeleteContatoCommand(long id, Contato item) : base(id, item)
        {
        }
    }
}
