using Pso.BackEnd.Command.Request.Generic;
using PSO.BackEnd.Domain.Entities;
using PSO.BackEnd.Domain.Interfaces.Repositories.NoSQLMdb;
using System.Threading;
using System.Threading.Tasks;

namespace Pso.BackEnd.Command.Handles.HandlerFatura
{
    public class FaturaDeletedNotificationHandler : DeletedNotificationHandler<Fatura>
    {
        private readonly IWriteMongoRepository<Pedido> _writeRepository;
        private readonly IReadMongoRepository<Pedido> _readRepository;

        public FaturaDeletedNotificationHandler(IWriteMongoRepository<Fatura> repository,
            IWriteMongoRepository<Pedido> writeRepository,
            IReadMongoRepository<Pedido> readRepository) : base(repository)
        {
            _writeRepository = writeRepository;
            _readRepository = readRepository;
        }

        public override async Task Handle(DeleteCommand<Fatura> notification, CancellationToken cancellationToken)
        {
            var pedido = await _readRepository.SingleAsync(c => c.Id.Equals(notification.Item.PedidoId));
            pedido.Fatura = null;
            await _writeRepository.UpdateAsync(pedido);
            await Task.CompletedTask;
        }
    }
}
