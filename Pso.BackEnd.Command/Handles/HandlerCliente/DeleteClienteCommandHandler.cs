using PSO.BackEnd.Domain.Entities;
using PSO.BackEnd.Domain.Interfaces.Repositories.Ef.Write;
using PSO.BackEnd.Domain.Interfaces.Repositories.UnitOfWork;

namespace Pso.BackEnd.Command.Handles.HandlerCliente
{
    public class DeleteClienteCommandHandler : DeleteCommandHandler<Cliente>
    {
        public DeleteClienteCommandHandler(IClienteWriteEfRepository repository, IUnitOfWork uow) : base(repository, uow)
        {
        }
    }
}
