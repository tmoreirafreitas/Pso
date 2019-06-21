using PSO.BackEnd.Domain.Entities;
using PSO.BackEnd.Domain.Interfaces.Repositories.Ef.Write;
using PSO.BackEnd.Domain.Interfaces.Repositories.UnitOfWork;

namespace Pso.BackEnd.Command.Handles.HandlerContato
{
    public class CreateContatoCommandHandler : CreateCommandHandler<Contato>
    {
        public CreateContatoCommandHandler(IContatoWriteEfRepository repository, IUnitOfWork uow) : base(repository, uow)
        {
        }
    }
}
