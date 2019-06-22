using Pso.BackEnd.Command.Request.Generic;
using PSO.BackEnd.Domain.Entities;

namespace Pso.BackEnd.Command.Request.RequestParcela
{
    public class DeleteParcelaCommand : DeleteCommand<Parcela>
    {
        public DeleteParcelaCommand(long id, Parcela item) : base(id, item)
        {
        }
    }
}
