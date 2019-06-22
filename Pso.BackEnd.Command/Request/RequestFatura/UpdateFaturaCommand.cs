using Pso.BackEnd.Command.Request.Generic;
using PSO.BackEnd.Domain.Entities;

namespace Pso.BackEnd.Command.Request.RequestFatura
{
    public class UpdateFaturaCommand : UpdateCommand<Fatura>
    {
        public UpdateFaturaCommand(long id, Fatura item) : base(id, item)
        {
        }
    }
}
