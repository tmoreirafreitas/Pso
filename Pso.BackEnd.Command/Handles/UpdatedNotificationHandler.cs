using MediatR;
using Pso.BackEnd.Command.Notifications;
using PSO.BackEnd.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Pso.BackEnd.Command.Handles
{
    public class UpdatedNotificationHandler<T> : INotificationHandler<UpdatedCommand<T>> where T : Entity
    {
        public Task Handle(UpdatedCommand<T> notification, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
