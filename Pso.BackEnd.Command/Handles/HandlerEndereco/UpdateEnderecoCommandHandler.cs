using MediatR;
using Pso.BackEnd.Command.Request.Generic;
using PSO.BackEnd.Domain.Entities;
using PSO.BackEnd.Domain.Interfaces.Repositories.Ef.Write;
using PSO.BackEnd.Domain.Interfaces.Repositories.UnitOfWork;
using System.Threading;
using System.Threading.Tasks;

namespace Pso.BackEnd.Command.Handles.HandlerEndereco
{
    public class UpdateEnderecoCommandHandler : UpdateCommandHandler<Endereco>
    {
        public UpdateEnderecoCommandHandler(IEnderecoWriteEfRepository repository, IUnitOfWork uow, IMediator mediator) : base(repository, uow, mediator)
        {
        }
        public override async Task<bool> Handle(UpdateCommand<Endereco> request, CancellationToken cancellationToken)
        {
            var committed = await UpdateCommandItem(request).ConfigureAwait(false);
            if (committed)
            {
                await _mediator.Publish(request);
            }
            return committed;
        }
    }
}
