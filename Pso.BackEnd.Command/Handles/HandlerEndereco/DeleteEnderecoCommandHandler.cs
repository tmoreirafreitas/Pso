using PSO.BackEnd.Domain.Entities;
using PSO.BackEnd.Domain.Interfaces.Repositories.Ef.Write;
using PSO.BackEnd.Domain.Interfaces.Repositories.UnitOfWork;

namespace Pso.BackEnd.Command.Handles.HandlerEndereco
{
    public class DeleteEnderecoCommandHandler : DeleteCommandHandler<Endereco>
    {
        public DeleteEnderecoCommandHandler(IEnderecoWriteEfRepository repository, IUnitOfWork uow) : base(repository, uow)
        {
        }
    }
}
