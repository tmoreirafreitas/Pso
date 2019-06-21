using Pso.BackEnd.Command.Request.Generic;
using PSO.BackEnd.Domain.Entities;

namespace Pso.BackEnd.Command.Request.RequestContato
{
    public class CreateContatoCommand : CreateCommand<Contato>
    {
        public CreateContatoCommand(Contato item) : base(item)
        {
        }
    }
}
