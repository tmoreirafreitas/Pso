using Pso.BackEnd.Command.Request.Generic;
using PSO.BackEnd.Domain.Entities;

namespace Pso.BackEnd.Command.Request.RequestLente
{
    public class CreateLenteCommand : CreateCommand<Lente>
    {
        public CreateLenteCommand(Lente item) : base(item)
        {
        }
    }
}
