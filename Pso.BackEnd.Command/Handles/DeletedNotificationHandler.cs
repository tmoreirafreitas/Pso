using MediatR;
using Pso.BackEnd.Command.Notifications;
using PSO.BackEnd.Domain.Entities;
using PSO.BackEnd.Domain.Interfaces.Repositories.NoSQLMdb;
using System.Threading;
using System.Threading.Tasks;

namespace Pso.BackEnd.Command.Handles
{
    public class DeletedNotificationHandler<T> : INotificationHandler<DeletedCommand<T>> where T : Entity
    {
        private IWriteMongoRepository<T> _repository;

        public DeletedNotificationHandler(IWriteMongoRepository<T> repository)
        {
            _repository = repository;
        }

        public async Task Handle(DeletedCommand<T> notification, CancellationToken cancellationToken)
        {
            await _repository.DeleteAsync(notification.Id);
        }
    }
}
