using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Pso.BackEnd.Command.Request.Generic;
using PSO.BackEnd.Domain.Entities;
using PSO.BackEnd.Domain.Interfaces.Repositories.Ef.Write;
using PSO.BackEnd.Domain.Interfaces.Repositories.UnitOfWork;

namespace Pso.BackEnd.Command.Handles.HandlerContato
{
    public class CreateContatoCommandHandler : CreateCommandHandler<Contato>
    {
        public CreateContatoCommandHandler(IContatoWriteEfRepository repository, IUnitOfWork uow, IMediator mediator) : base(repository, uow, mediator)
        {
        }

        public override async Task<bool> Handle(CreateCommand<Contato> request, CancellationToken cancellationToken)
        {
            var committed = CreateCommandItem(request);
            if (committed)
            {
                await _mediator.Publish(request);
            }
            return committed;
        }
    }
}
