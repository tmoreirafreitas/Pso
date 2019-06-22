using Pso.BackEnd.Command.Request.Generic;
using PSO.BackEnd.Domain.Entities;

namespace Pso.BackEnd.Command.Request.RequestParcela
{
    public class UpdateParcelaCommand : UpdateCommand<Parcela>
    {
        public UpdateParcelaCommand(long id, Parcela item) : base(id, item)
        {
        }
    }
}
