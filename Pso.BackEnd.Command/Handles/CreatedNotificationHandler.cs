using MediatR;
using Pso.BackEnd.Command.Request.Generic;
using PSO.BackEnd.Domain.Entities;
using PSO.BackEnd.Domain.Interfaces.Repositories.NoSQLMdb;
using System.Threading;
using System.Threading.Tasks;

namespace Pso.BackEnd.Command.Handles
{
    public class CreatedNotificationHandler<T> : INotificationHandler<CreateCommand<T>> where T : Entity
    {
        protected readonly IWriteMongoRepository<T> _repository;

        public CreatedNotificationHandler(IWriteMongoRepository<T> repository)
        {
            _repository = repository;
        }

        public Task Handle(CreateCommand<T> notification, CancellationToken cancellationToken)
        {
            _repository.AddAsync(notification.Item);
            return Task.FromResult(true);
        }
    }
}
