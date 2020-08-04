using MediatR;
using Pso.Domain.Interfaces.Repositories.Ef.Write;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;

namespace Pso.Domain.Core.Cliente.Commands.Deletar
{
    public class DeletarClienteCommandHandler : IRequestHandler<DeletarClienteCommand, ResultCommand>
    {
        private readonly IClienteWriteEfRepository _clienteWriteEfRepository;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public DeletarClienteCommandHandler(IClienteWriteEfRepository clienteWriteEfRepository, IMediator mediator, IMapper mapper)
        {
            _clienteWriteEfRepository = clienteWriteEfRepository;
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<ResultCommand> Handle(DeletarClienteCommand request, CancellationToken cancellationToken)
        {
            await _clienteWriteEfRepository.DeleteAsync(c => c.Id == request.Id, cancellationToken).ConfigureAwait(false);
            await _mediator.Publish(new ClienteDeletado(request), cancellationToken).ConfigureAwait(false);
            return new ResultCommand<Entities.Cliente>(_mapper.Map<Entities.Cliente>(request));
        }
    }
}