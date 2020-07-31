using System;
using MediatR;

namespace Pso.Domain.Core.Notifications
{
    public class NotificationBase<TCommand> : INotification where TCommand : Message
    {
        public TCommand Command { get; set; }
        protected DateTime DataHora { get; set; } = DateTime.Now;

        public NotificationBase(TCommand command)
        {
            Command = command;
        }
    }
}