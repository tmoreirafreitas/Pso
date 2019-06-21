using PSO.BackEnd.Domain.Entities;
using PSO.BackEnd.Domain.Interfaces.Repositories.Ef.Write;
using PSO.BackEnd.Domain.Interfaces.Repositories.UnitOfWork;

namespace Pso.BackEnd.Command.Handles.HandlerEndereco
{
    public class UpdateEnderecoCommandHandler : UpdateCommandHandler<Endereco>
    {
        public UpdateEnderecoCommandHandler(IEnderecoWriteEfRepository repository, IUnitOfWork uow) : base(repository, uow)
        {
        }
    }
}
