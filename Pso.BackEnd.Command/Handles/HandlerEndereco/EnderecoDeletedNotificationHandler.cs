using Pso.BackEnd.Command.Request.Generic;
using PSO.BackEnd.Domain.Entities;
using PSO.BackEnd.Domain.Interfaces.Repositories.NoSQLMdb;
using System.Threading;
using System.Threading.Tasks;

namespace Pso.BackEnd.Command.Handles.HandlerEndereco
{
    public class EnderecoDeletedNotificationHandler : DeletedNotificationHandler<Endereco>
    {
        private readonly IWriteMongoRepository<Cliente> _clienteWriteRepository;
        private readonly IReadMongoRepository<Cliente> _clienteReadRepository;

        public EnderecoDeletedNotificationHandler(
            IWriteMongoRepository<Endereco> repository,
            IWriteMongoRepository<Cliente> writeMongoRepository,
            IReadMongoRepository<Cliente> readMongoRepository) : base(repository)
        {
            _clienteWriteRepository = writeMongoRepository;
            _clienteReadRepository = readMongoRepository;
        }

        public override async Task Handle(DeleteCommand<Endereco> notification, CancellationToken cancellationToken)
        {
            var cliente = await _clienteReadRepository.SingleAsync(c => c.Endereco.Id.Equals(notification.Id));
            cliente.Endereco = null;
            await _clienteWriteRepository.DeleteAsync(cliente);
            await Task.CompletedTask;
        }
    }
}
