using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Pso.Domain.Interfaces.Repositories.NoSqlMongoDb.Read;
using Pso.Domain.Interfaces.Repositories.NoSqlMongoDb.Write;
using System.Linq;

namespace Pso.Domain.Core.Contato.Commands.Cadastrar
{
    public class ContatoCadastradoNotificationHandler : INotificationHandler<ContatoCadastrado>
    {
        private readonly IClienteWriteMongoRepository _clienteWriteMongoRepository;
        private readonly IClienteReadMongoRepository _clienteReadMongoRepository;
        private readonly IMapper _mapper;

        public ContatoCadastradoNotificationHandler(IClienteWriteMongoRepository clienteWriteMongoRepository, IClienteReadMongoRepository clienteReadMongoRepository, IMapper mapper)
        {
            _clienteWriteMongoRepository = clienteWriteMongoRepository;
            _clienteReadMongoRepository = clienteReadMongoRepository;
            _mapper = mapper;
        }
        public async Task Handle(ContatoCadastrado notification, CancellationToken cancellationToken)
        {
            var cliente = await _clienteReadMongoRepository
                .SingleAsync(x => x.Id == notification.Command.ClienteId, cancellationToken).ConfigureAwait(false);

            if (cliente != null)
            {
                if (cliente.Contatos.All(x => x.Telefone != notification.Command.Telefone))
                {
                    var contato = _mapper.Map<Entities.Contato>(notification.Command);
                    (cliente.Contatos as ICollection<Entities.Contato>)?.Add(contato);
                    await _clienteWriteMongoRepository.UpdateAsync(cliente);
                }
            }
        }
    }
}