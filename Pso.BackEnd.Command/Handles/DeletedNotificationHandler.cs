using MediatR;
using Pso.BackEnd.Command.Request.Generic;
using PSO.BackEnd.Domain.Entities;
using PSO.BackEnd.Domain.Interfaces.Repositories.NoSQLMdb;
using System.Threading;
using System.Threading.Tasks;

namespace Pso.BackEnd.Command.Handles
{
    public class DeletedNotificationHandler<T> : INotificationHandler<DeleteCommand<T>> where T : Entity
    {
        private IWriteMongoRepository<T> _repository;

        public DeletedNotificationHandler(IWriteMongoRepository<T> repository)
        {
            _repository = repository;
        }

        public virtual Task Handle(DeleteCommand<T> notification, CancellationToken cancellationToken)
        {
            _repository.DeleteAsync(notification.Id);
            return Task.CompletedTask;
        }
    }
}
