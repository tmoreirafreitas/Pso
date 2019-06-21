using PSO.BackEnd.Domain.Entities;
using PSO.BackEnd.Domain.Interfaces.Repositories.Ef.Write;
using PSO.BackEnd.Domain.Interfaces.Repositories.UnitOfWork;

namespace Pso.BackEnd.Command.Handles.HandlerContato
{
    public class UpdateContatoCommandHandler : UpdateCommandHandler<Contato>
    {
        public UpdateContatoCommandHandler(IContatoWriteEfRepository repository, IUnitOfWork uow) : base(repository, uow)
        {
        }
    }
}
