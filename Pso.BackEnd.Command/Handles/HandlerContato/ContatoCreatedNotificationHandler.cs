using Pso.BackEnd.Command.Request.Generic;
using PSO.BackEnd.Domain.Entities;
using PSO.BackEnd.Domain.Interfaces.Repositories.NoSQLMdb;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Pso.BackEnd.Command.Handles.HandlerContato
{
    public class ContatoCreatedNotificationHandler : CreatedNotificationHandler<Contato>
    {
        private readonly IWriteMongoRepository<Cliente> _clienteWriteRepository;
        private readonly IReadMongoRepository<Cliente> _clienteReadRepository;
        public ContatoCreatedNotificationHandler(IWriteMongoRepository<Contato> repository,
            IWriteMongoRepository<Cliente> writeMongoRepository,
            IReadMongoRepository<Cliente> readMongoRepository) : base(repository)
        {
            _clienteWriteRepository = writeMongoRepository;
            _clienteReadRepository = readMongoRepository;
        }

        public override async Task Handle(CreateCommand<Contato> notification, CancellationToken cancellationToken)
        {
            var cliente = await _clienteReadRepository.SingleAsync(c => c.Contatos.SingleOrDefault(ct => ct.ClienteId.Equals(notification.Item.Id)) != null);
            cliente.Contatos.Add(notification.Item);
            await _clienteWriteRepository.AddAsync(cliente);
            await Task.CompletedTask;
        }
    }
}
