using PSO.BackEnd.Domain.Entities;
using PSO.BackEnd.Domain.Interfaces.Repositories.Ef.Write;
using PSO.BackEnd.Domain.Interfaces.Repositories.UnitOfWork;

namespace Pso.BackEnd.Command.Handles.HandlerLente
{
    public class UpdateLenteCommandHandler : UpdateCommandHandler<Lente>
    {
        public UpdateLenteCommandHandler(ILenteWriteEfRepository repository, IUnitOfWork uow) : base(repository, uow)
        {
        }
    }
}
