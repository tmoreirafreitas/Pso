using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Pso.BackEnd.Command.Request.Generic;
using PSO.BackEnd.Domain.Entities;
using PSO.BackEnd.Domain.Interfaces.Repositories.Ef.Write;
using PSO.BackEnd.Domain.Interfaces.Repositories.UnitOfWork;

namespace Pso.BackEnd.Command.Handles.HandlerFatura
{
    public class CreateFaturaCommandHandler : CreateCommandHandler<Fatura>
    {
        public CreateFaturaCommandHandler(IFaturaWriteEfRepository repository, IUnitOfWork uow, IMediator mediator) : base(repository, uow, mediator)
        {
        }
        public override async Task<bool> Handle(CreateCommand<Fatura> request, CancellationToken cancellationToken)
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
