using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Pso.Domain.Interfaces.Repositories.NoSqlMongoDb.Read;
using Pso.Domain.Interfaces.Repositories.NoSqlMongoDb.Write;

namespace Pso.Domain.Core.Contato.Commands.Deletar
{
    public class ContatoDeletadoNotificationHandler : INotificationHandler<ContatoDeletado>
    {
        private readonly IClienteWriteMongoRepository _clienteWriteMongoRepository;
        private readonly IClienteReadMongoRepository _clienteReadMongoRepository;

        public ContatoDeletadoNotificationHandler(IClienteWriteMongoRepository clienteWriteMongoRepository, 
            IClienteReadMongoRepository clienteReadMongoRepository)
        {
            _clienteWriteMongoRepository = clienteWriteMongoRepository;
            _clienteReadMongoRepository = clienteReadMongoRepository;
        }

        public async Task Handle(ContatoDeletado notification, CancellationToken cancellationToken)
        {
            var cliente = await _clienteReadMongoRepository.SingleAsync(c => c.Contatos, ct => ct.Id == notification.Command.Id, cancellationToken)
                .ConfigureAwait(false);
            var contato = cliente?.Contatos.SingleOrDefault(c => c.Id == notification.Command.Id);
            if (contato != null)
            {
                (cliente.Contatos as ICollection<Entities.Contato>)?.Remove(contato);
                await _clienteWriteMongoRepository.UpdateAsync(cliente).ConfigureAwait(false);
            }
        }
    }
}