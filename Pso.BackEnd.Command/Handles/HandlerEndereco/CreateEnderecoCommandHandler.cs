using MediatR;
using Pso.BackEnd.Command.Request.Generic;
using PSO.BackEnd.Domain.Entities;
using PSO.BackEnd.Domain.Interfaces.Repositories.Ef.Write;
using PSO.BackEnd.Domain.Interfaces.Repositories.UnitOfWork;
using System.Threading;
using System.Threading.Tasks;

namespace Pso.BackEnd.Command.Handles.HandlerEndereco
{
    public class CreateEnderecoCommandHandler : CreateCommandHandler<Endereco>
    {
        public CreateEnderecoCommandHandler(IEnderecoWriteEfRepository repository, IUnitOfWork uow, IMediator mediator) : base(repository, uow, mediator)
        {
        }

        public override async Task<bool> Handle(CreateCommand<Endereco> request, CancellationToken cancellationToken)
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
