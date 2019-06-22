using PSO.BackEnd.Domain.Entities;
using PSO.BackEnd.Domain.Interfaces.Repositories.Ef.Write;
using PSO.BackEnd.Domain.Interfaces.Repositories.UnitOfWork;

namespace Pso.BackEnd.Command.Handles.HandlerFatura
{
    public class DeleteFaturaCommandHandler : DeleteCommandHandler<Fatura>
    {
        public DeleteFaturaCommandHandler(IFaturaWriteEfRepository repository, IUnitOfWork uow) : base(repository, uow)
        {
        }
    }
}
