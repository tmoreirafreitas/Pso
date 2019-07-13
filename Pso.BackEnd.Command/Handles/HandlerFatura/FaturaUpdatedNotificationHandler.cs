using Pso.BackEnd.Command.Request.Generic;
using PSO.BackEnd.Domain.Entities;
using PSO.BackEnd.Domain.Interfaces.Repositories.NoSQLMdb;
using System.Threading;
using System.Threading.Tasks;

namespace Pso.BackEnd.Command.Handles.HandlerFatura
{
    public class FaturaUpdatedNotificationHandler : UpdatedNotificationHandler<Fatura>
    {
        private readonly IWriteMongoRepository<Pedido> _writeRepository;
        private readonly IReadMongoRepository<Pedido> _readRepository;
        public FaturaUpdatedNotificationHandler(IWriteMongoRepository<Fatura> repository,
             IWriteMongoRepository<Pedido> writeMongoRepository,
             IReadMongoRepository<Pedido> readMongoRepository) : base(repository)
        {
            _writeRepository = writeMongoRepository;
            _readRepository = readMongoRepository;
        }

        public override async Task Handle(UpdateCommand<Fatura> notification, CancellationToken cancellationToken)
        {
            var pedido = await _readRepository.SingleAsync(c => c.Id.Equals(notification.Item.PedidoId));
            pedido.Fatura = notification.Item;
            await _writeRepository.UpdateAsync(pedido);
            await Task.CompletedTask;
        }
    }
}
