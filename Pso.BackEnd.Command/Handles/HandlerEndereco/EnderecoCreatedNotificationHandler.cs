using Pso.BackEnd.Command.Request.Generic;
using PSO.BackEnd.Domain.Entities;
using PSO.BackEnd.Domain.Interfaces.Repositories.NoSQLMdb;
using System.Threading;
using System.Threading.Tasks;

namespace Pso.BackEnd.Command.Handles.HandlerEndereco
{
    public class EnderecoCreatedNotificationHandler : CreatedNotificationHandler<Endereco>
    {
        private readonly IWriteMongoRepository<Cliente> _clienteWriteRepository;
        private readonly IReadMongoRepository<Cliente> _clienteReadRepository;
        public EnderecoCreatedNotificationHandler(
            IWriteMongoRepository<Endereco> repository,
            IWriteMongoRepository<Cliente> writeMongoRepository,
            IReadMongoRepository<Cliente> readMongoRepository) : base(repository)
        {
            _clienteWriteRepository = writeMongoRepository;
            _clienteReadRepository = readMongoRepository;
        }

        public override async Task Handle(CreateCommand<Endereco> notification, CancellationToken cancellationToken)
        {
            var cliente = await _clienteReadRepository.SingleAsync(c => c.Id.Equals(notification.Item.ClienteId));
            cliente.Endereco = notification.Item;
            await _clienteWriteRepository.AddAsync(cliente);
            await Task.CompletedTask;
        }
    }
}
