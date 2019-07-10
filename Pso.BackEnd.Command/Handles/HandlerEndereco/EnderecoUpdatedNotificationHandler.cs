using MediatR;
using Pso.BackEnd.Command.Request.RequestEndereco;
using PSO.BackEnd.Domain.Entities;
using PSO.BackEnd.Domain.Interfaces.Repositories.NoSQLMdb;
using System.Threading;
using System.Threading.Tasks;

namespace Pso.BackEnd.Command.Handles.HandlerEndereco
{
    public class EnderecoUpdatedNotificationHandler : INotificationHandler<UpdateEnderecoCommand>
    {
        private readonly IWriteMongoRepository<Cliente> _clienteWriteRepository;
        private readonly IReadMongoRepository<Cliente> _clienteReadRepository;
        public EnderecoUpdatedNotificationHandler(IWriteMongoRepository<Cliente> clienteWriteRepository,
            IReadMongoRepository<Cliente> clienteReadRepository)
        {
            _clienteWriteRepository = clienteWriteRepository;
            _clienteReadRepository = clienteReadRepository;
        }

        public async Task Handle(UpdateEnderecoCommand notification, CancellationToken cancellationToken)
        {
            var cliente = await _clienteReadRepository.SingleAsync(c => c.Endereco.Id.Equals(notification.Id));
            cliente.Endereco = notification.Item;
            await _clienteWriteRepository.UpdateAsync(cliente);
            await Task.CompletedTask;
        }
    }
}
