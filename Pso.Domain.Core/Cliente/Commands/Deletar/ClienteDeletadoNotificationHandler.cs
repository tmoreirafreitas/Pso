using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Pso.Domain.Interfaces.Repositories.NoSqlMongoDb.Write;

namespace Pso.Domain.Core.Cliente.Commands.Deletar
{
    public class ClienteDeletadoNotificationHandler : INotificationHandler<ClienteDeletado>
    {
        private readonly IClienteWriteMongoRepository _clienteWriteMongoRepository;

        public ClienteDeletadoNotificationHandler(IClienteWriteMongoRepository clienteWriteMongoRepository)
        {
            _clienteWriteMongoRepository = clienteWriteMongoRepository;
        }

        public Task Handle(ClienteDeletado notification, CancellationToken cancellationToken)
        {
            _clienteWriteMongoRepository.DeleteAsync(x => x.Id == notification.Command.Id, cancellationToken).ConfigureAwait(false);
            return Task.CompletedTask;
        }
    }
}