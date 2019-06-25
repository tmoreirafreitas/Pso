using MediatR;
using Pso.BackEnd.Command.Request.Generic;
using PSO.BackEnd.Domain.Entities;

namespace Pso.BackEnd.Command.Notifications
{
    public class UpdatedCommand<T> : UpdateCommand<T>, INotification where T : Entity
    {
        public UpdatedCommand(long id, T item) : base(id, item)
        {
        }
    }
}
