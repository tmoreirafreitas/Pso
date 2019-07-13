using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Pso.BackEnd.Command.Request.Generic;
using PSO.BackEnd.Domain.Entities;
using PSO.BackEnd.Domain.Interfaces.Repositories.Ef.Write;
using PSO.BackEnd.Domain.Interfaces.Repositories.UnitOfWork;

namespace Pso.BackEnd.Command.Handles.HandlerParcela
{
    public class DeleteParcelaCommandHandler : DeleteCommandHandler<Parcela>
    {
        public DeleteParcelaCommandHandler(IParcelaWriteEfRepository repository, IUnitOfWork uow, IMediator mediator) : base(repository, uow, mediator)
        {
        }

        public override Task<bool> Handle(DeleteCommand<Parcela> request, CancellationToken cancellationToken)
        {
            var commited = DeleteCommandItem(request);
            if (commited)
            {
                _mediator.Publish(request);
            }
            return Task.FromResult(commited);
        }
    }
}
