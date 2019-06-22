using Pso.BackEnd.Command.Request.Generic;
using PSO.BackEnd.Domain.Entities;

namespace Pso.BackEnd.Command.Request.RequestParcela
{
    public class CreateParcelaCommand : CreateCommand<Parcela>
    {
        public CreateParcelaCommand(Parcela item) : base(item)
        {
        }
    }
}
