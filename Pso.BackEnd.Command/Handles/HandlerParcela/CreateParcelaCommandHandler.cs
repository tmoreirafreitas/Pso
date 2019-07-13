using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Pso.BackEnd.Command.Request.Generic;
using PSO.BackEnd.Domain.Entities;
using PSO.BackEnd.Domain.Interfaces.Repositories.Ef.Write;
using PSO.BackEnd.Domain.Interfaces.Repositories.UnitOfWork;

namespace Pso.BackEnd.Command.Handles.HandlerParcela
{
    public class CreateParcelaCommandHandler : CreateCommandHandler<Parcela>
    {
        public CreateParcelaCommandHandler(IParcelaWriteEfRepository repository, IUnitOfWork uow, IMediator mediator) : base(repository, uow, mediator)
        {
        }

        public override async Task<bool> Handle(CreateCommand<Parcela> request, CancellationToken cancellationToken)
        {
            var commited = CreateCommandItem(request);
            if (commited)
            {
                await _mediator.Publish(request);
            }
            return commited;
        }
    }
}
