using Pso.BackEnd.Command.Request.Generic;
using PSO.BackEnd.Domain.Entities;

namespace Pso.BackEnd.Command.Request.RequestLente
{
    public class DeleteLenteCommand : DeleteCommand<Lente>
    {
        public DeleteLenteCommand(long id, Lente item) : base(id, item)
        {
        }
    }
}
