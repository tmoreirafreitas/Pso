using AutoMapper;
using MediatR;
using Pso.Domain.Interfaces.Repositories.Ef.Read;
using Pso.Domain.Interfaces.Repositories.Ef.Write;
using Pso.Domain.Interfaces.Repositories.UnitOfWork;
using System.Threading;
using System.Threading.Tasks;

namespace Pso.Domain.Core.Contato.Commands.Cadastrar
{
    public class CadastrarContatoCommandHandler: IRequestHandler<CadastrarContatoCommand, ResultCommand<Entities.Contato>>
    {
        private readonly IContatoWriteEfRepository _contatoWriteEfRepository;
        private readonly IContatoReadEfRepository _contatoReadEfRepository;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly IUnitOfWork _uow;

        public CadastrarContatoCommandHandler(IContatoWriteEfRepository contatoWriteEfRepository, IContatoReadEfRepository contatoReadEfRepository, IMapper mapper, IMediator mediator, IUnitOfWork uow)
        {
            _contatoWriteEfRepository = contatoWriteEfRepository;
            _contatoReadEfRepository = contatoReadEfRepository;
            _mapper = mapper;
            _mediator = mediator;
            _uow = uow;
        }
        public async Task<ResultCommand<Entities.Contato>> Handle(CadastrarContatoCommand request, CancellationToken cancellationToken)
        {
            var item = await _contatoReadEfRepository.SingleAsync(x => x.Telefone == request.Telefone);
            if (item == null)
            {
                var contato = _mapper.Map<Entities.Contato>(request);
                await _contatoWriteEfRepository.AddAsync(contato, cancellationToken).ConfigureAwait(false);
                await _uow.CommitAsync();
                await _mediator.Publish(new ContatoCadastrado(request), cancellationToken).ConfigureAwait(false);
            }
            return new ResultCommand<Entities.Contato>();
        }
    }
}