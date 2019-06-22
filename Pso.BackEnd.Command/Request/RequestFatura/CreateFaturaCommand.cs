using Pso.BackEnd.Command.Request.Generic;
using PSO.BackEnd.Domain.Entities;

namespace Pso.BackEnd.Command.Request.RequestFatura
{
    public class CreateFaturaCommand : CreateCommand<Fatura>
    {
        public CreateFaturaCommand(Fatura item) : base(item)
        {
        }
    }
}
