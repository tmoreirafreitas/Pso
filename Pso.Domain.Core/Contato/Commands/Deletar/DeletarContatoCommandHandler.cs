using MediatR;
using Pso.Domain.Interfaces.Repositories.Ef.Write;
using System.Threading;
using System.Threading.Tasks;

namespace Pso.Domain.Core.Contato.Commands.Deletar
{
    public class DeletarContatoCommandHandler : IRequestHandler<DeletarContatoCommand, ResultCommand>
    {
        private readonly IContatoWriteEfRepository _contatoWriteEfRepository;
        private readonly IMediator _mediator;

        public DeletarContatoCommandHandler(IContatoWriteEfRepository contatoWriteEfRepository, IMediator mediator)
        {
            _contatoWriteEfRepository = contatoWriteEfRepository;
            _mediator = mediator;
        }
        public Task<ResultCommand> Handle(DeletarContatoCommand request, CancellationToken cancellationToken)
        {
            _contatoWriteEfRepository.DeleteAsync(x => x.Id == request.Id && x.ClienteId == request.ClientId, cancellationToken)
                .ConfigureAwait(false);
            _mediator.Publish(new ContatoDeletado(request), cancellationToken).ConfigureAwait(false);
            return Task.FromResult(ResultCommand.Ok);
        }
    }
}