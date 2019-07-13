using Pso.BackEnd.Command.Request.Generic;
using PSO.BackEnd.Domain.Entities;
using PSO.BackEnd.Domain.Interfaces.Repositories.NoSQLMdb;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Pso.BackEnd.Command.Handles.HandlerParcela
{
    public class ParcelaCreatedNotificationHandler : CreatedNotificationHandler<Parcela>
    {
        private readonly IWriteMongoRepository<Pedido> _writeRepository;
        private readonly IReadMongoRepository<Pedido> _readRepository;
        public ParcelaCreatedNotificationHandler(IWriteMongoRepository<Parcela> repository,
            IWriteMongoRepository<Pedido> writeMongoRepository,
            IReadMongoRepository<Pedido> readMongoRepository) : base(repository)
        {
            _writeRepository = writeMongoRepository;
            _readRepository = readMongoRepository;
        }

        public override async Task Handle(CreateCommand<Parcela> notification, CancellationToken cancellationToken)
        {
            var pedido = await _readRepository.SingleAsync(c => c.Fatura.Parcelas, p => p.FaturaId.Equals(notification.Item.FaturaId));
            pedido.Fatura.Parcelas.Add(notification.Item);
            await _writeRepository.UpdateAsync(pedido);
            await Task.CompletedTask;
            //var pedido = await _readRepository.SingleAsync(c => c.Fatura.Parcelas, p => p.FaturaId.Equals(notification.Item.FaturaId));
            //var parcela = pedido.Fatura.Parcelas.FirstOrDefault(p => p.Id.Equals(notification.Item.Id));
            //pedido.Fatura.Parcelas.Remove(parcela);
            //pedido.Fatura.Parcelas.Add(notification.Item);
            //await _writeRepository.UpdateAsync(pedido);
            //await Task.CompletedTask;
        }
    }
}
