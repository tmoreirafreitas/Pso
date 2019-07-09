using MediatR;
using Pso.BackEnd.Command.Request.Generic;
using PSO.BackEnd.Domain.Entities;
using PSO.BackEnd.Domain.Interfaces.Repositories.NoSQLMdb;
using System.Threading;
using System.Threading.Tasks;

namespace Pso.BackEnd.Command.Handles
{
    public class UpdatedNotificationHandler<T> : INotificationHandler<UpdateCommand<T>> where T : Entity
    {
        private IWriteMongoRepository<T> _repository;


        public UpdatedNotificationHandler(IWriteMongoRepository<T> repository)
        {
            _repository = repository;
        }

        public Task Handle(UpdateCommand<T> notification, CancellationToken cancellationToken)
        {

            _repository.UpdateAsync(notification.Item);
            return Task.CompletedTask;
        }
    }
}
