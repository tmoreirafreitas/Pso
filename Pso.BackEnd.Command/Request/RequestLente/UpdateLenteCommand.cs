using Pso.BackEnd.Command.Request.Generic;
using PSO.BackEnd.Domain.Entities;

namespace Pso.BackEnd.Command.Request.RequestLente
{
    public class UpdateLenteCommand : UpdateCommand<Lente>
    {
        public UpdateLenteCommand(long id, Lente item) : base(id, item)
        {
        }
    }
}
