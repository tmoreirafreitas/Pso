using MediatR;
using Pso.BackEnd.Command.Request.Generic;
using PSO.BackEnd.Domain.Entities;

namespace Pso.BackEnd.Command.Notifications
{
    public class DeletedCommand<T> : DeleteCommand<T>, INotification where T : Entity
    {
        public DeletedCommand(long id, T item) : base(id, item)
        {
        }
    }
}
