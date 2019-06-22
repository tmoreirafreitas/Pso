using Pso.BackEnd.Command.Request.Generic;
using PSO.BackEnd.Domain.Entities;

namespace Pso.BackEnd.Command.Request.RequestFatura
{
    public class DeleteFaturaCommand : DeleteCommand<Fatura>
    {
        public DeleteFaturaCommand(long id, Fatura item) : base(id, item)
        {
        }
    }
}
