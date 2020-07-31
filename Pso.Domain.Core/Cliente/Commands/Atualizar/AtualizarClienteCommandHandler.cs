using AutoMapper;
using MediatR;
using Pso.Domain.Interfaces.Repositories.Ef.Write;
using System.Threading;
using System.Threading.Tasks;

namespace Pso.Domain.Core.Cliente.Commands.Atualizar
{
    public class AtualizarClienteCommandHandler : IRequestHandler<AtualizarClienteCommand, ResultCommand>
    {
        private readonly IClienteWriteEfRepository _clienteWriteEfRepository;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public AtualizarClienteCommandHandler(IClienteWriteEfRepository clienteWriteEfRepository, IMapper mapper, IMediator mediator)
        {
            _clienteWriteEfRepository = clienteWriteEfRepository;
            _mapper = mapper;
            _mediator = mediator;
        }
        public async Task<ResultCommand> Handle(AtualizarClienteCommand request, CancellationToken cancellationToken)
        {
            var item = _mapper.Map<Entities.Cliente>(request);
            if (item.Id != 0) return null;
            var client = await _clienteWriteEfRepository.Update(item).ConfigureAwait(false);
            await _mediator.Publish(new ClienteAtualizado(request), cancellationToken).ConfigureAwait(false);
            return new ResultCommand<Entities.Cliente>(client);
        }
    }
}