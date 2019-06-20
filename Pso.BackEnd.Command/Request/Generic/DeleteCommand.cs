using MediatR;
using PSO.BackEnd.Domain.Entities;

namespace Pso.BackEnd.Command.Request.Generic
{
    public class DeleteCommand<T> : Command<T>, IRequest<bool> where T : Entity
    {
        public long Id { get; private set; }

        public DeleteCommand(long id, T item) : base(item)
        {
            Id = id;
        }
    }
}
