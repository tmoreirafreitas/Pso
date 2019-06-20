using PSO.BackEnd.Domain.Entities;
using PSO.BackEnd.Domain.Interfaces.Repositories.Ef.Write;
using PSO.BackEnd.Domain.Interfaces.Repositories.UnitOfWork;

namespace Pso.BackEnd.Command.Handles.HandlerCliente
{
    public class UpdateClienteCommandHandler : UpdateCommandHandler<Cliente>
    {
        public UpdateClienteCommandHandler(IClienteWriteEfRepository repository, IUnitOfWork uow) : base(repository, uow)
        {
        }
    }
}
