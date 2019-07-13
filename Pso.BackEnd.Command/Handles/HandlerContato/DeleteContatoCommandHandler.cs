using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Pso.BackEnd.Command.Request.Generic;
using PSO.BackEnd.Domain.Entities;
using PSO.BackEnd.Domain.Interfaces.Repositories.Ef.Read;
using PSO.BackEnd.Domain.Interfaces.Repositories.Ef.Write;
using PSO.BackEnd.Domain.Interfaces.Repositories.UnitOfWork;

namespace Pso.BackEnd.Command.Handles.HandlerContato
{
    public class DeleteContatoCommandHandler : DeleteCommandHandler<Contato>
    {
        private readonly IContatoReadEfRepository _contatoReadEfRepository;
        public DeleteContatoCommandHandler(IContatoWriteEfRepository repository, 
            IContatoReadEfRepository contatoReadEfRepository,
            IUnitOfWork uow, IMediator mediator) : base(repository, uow, mediator)
        {
            _contatoReadEfRepository = contatoReadEfRepository;
        }

        public override Task<bool> Handle(DeleteCommand<Contato> request, CancellationToken cancellationToken)
        {
            var commited = false;
            var contato = _contatoReadEfRepository.Single(c => c.Id.Equals(request.Item.Id) && c.ClienteId.Equals(request.Item.ClienteId));
            if (contato != null)
            {
                commited = DeleteCommandItem(request);
                if (commited)
                    _mediator.Publish(request);
            }
            return Task.FromResult(commited);
        }
    }
}
