using AutoMapper;
using MediatR;
using Pso.Domain.Interfaces.Repositories.Ef.Write;
using System.Threading;
using System.Threading.Tasks;
using Pso.Domain.Interfaces.Repositories.UnitOfWork;

namespace Pso.Domain.Core.Cliente.Commands.Cadastrar
{
    public class CadastrarClienteCommandHandler : IRequestHandler<CadastrarClienteCommand, ResultCommand<Entities.Cliente>>
    {
        private readonly IClienteWriteEfRepository _clienteWriteEfRepository;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly IUnitOfWork _uow;

        public CadastrarClienteCommandHandler(IClienteWriteEfRepository clienteWriteEfRepository, IMapper mapper, IMediator mediator, IUnitOfWork uow)
        {
            _clienteWriteEfRepository = clienteWriteEfRepository;
            _mapper = mapper;
            _mediator = mediator;
            _uow = uow;
        }

        public async Task<ResultCommand<Entities.Cliente>> Handle(CadastrarClienteCommand request, CancellationToken cancellationToken)
        {
            var item = _mapper.Map<Entities.Cliente>(request);
            if (item.Id != 0) return null;
            var cliente = await _clienteWriteEfRepository.AddAsync(item, cancellationToken).ConfigureAwait(false);
            if (!await _uow.CommitAsync()) return null;
            request.Id = cliente.Id;
            await _mediator.Publish(new ClienteCadastrado(request), cancellationToken).ConfigureAwait(false);
            return new ResultCommand<Entities.Cliente>(cliente);
        }
    }
}