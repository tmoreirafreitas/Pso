using Pso.BackEnd.Command.Request.Generic;
using PSO.BackEnd.Domain.Entities;
using PSO.BackEnd.Domain.Interfaces.Repositories.NoSQLMdb;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Pso.BackEnd.Command.Handles.HandlerContato
{
    public class ContatoUpdatedNotificationHandler : UpdatedNotificationHandler<Contato>
    {
        private readonly IWriteMongoRepository<Cliente> _clienteWriteRepository;
        private readonly IReadMongoRepository<Cliente> _clienteReadRepository;
        public ContatoUpdatedNotificationHandler(IWriteMongoRepository<Contato> repository,
            IWriteMongoRepository<Cliente> writeMongoRepository,
            IReadMongoRepository<Cliente> readMongoRepository) : base(repository)
        {
            _clienteWriteRepository = writeMongoRepository;
            _clienteReadRepository = readMongoRepository;
        }

        public override async Task Handle(UpdateCommand<Contato> notification, CancellationToken cancellationToken)
        {
            var cliente = await _clienteReadRepository.SingleAsync(c => c.Id.Equals(notification.Item.ClienteId));
            var contatoRemove = cliente.Contatos.SingleOrDefault(c => c.Id.Equals(notification.Item.Id) && c.ClienteId.Equals(notification.Item.ClienteId));
            cliente.Contatos.Remove(contatoRemove);
            cliente.Contatos.Add(notification.Item);
            await _clienteWriteRepository.UpdateAsync(cliente);
            await Task.CompletedTask;
        }
    }
}
