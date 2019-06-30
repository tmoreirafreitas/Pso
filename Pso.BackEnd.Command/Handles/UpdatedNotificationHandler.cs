using MediatR;
using Pso.BackEnd.Command.Notifications;
using PSO.BackEnd.Domain.Entities;
using PSO.BackEnd.Domain.Interfaces.Repositories.NoSQLMdb;
using System.Threading;
using System.Threading.Tasks;

namespace Pso.BackEnd.Command.Handles
{
    public class UpdatedNotificationHandler<T> : INotificationHandler<UpdatedCommand<T>> where T : Entity
    {
        private IWriteMongoRepository<T> _repository;

        public UpdatedNotificationHandler(IWriteMongoRepository<T> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdatedCommand<T> notification, CancellationToken cancellationToken)
        {
            await _repository.UpdateAsync(notification.Item);
        }
    }
}
