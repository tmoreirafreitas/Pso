using MediatR;
using Pso.BackEnd.Command.Request.Generic;
using PSO.BackEnd.Domain.Entities;

namespace Pso.BackEnd.Command.Notifications
{
    public class CreatedCommand<T> : CreateCommand<T>, INotification where T : Entity
    {
        public CreatedCommand(T item) : base(item)
        {
            
        }        
    }
}
