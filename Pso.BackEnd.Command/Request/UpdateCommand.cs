using MediatR;
using PSO.BackEnd.Domain.Entities;

namespace Pso.BackEnd.Command.Request
{
    public class UpdateCommand<T> : Command<T>, IRequest<bool> where T : Entity
    {
        public long Id { get; private set; }
        public UpdateCommand(long id, T item) : base(item)
        {
            Id = id;
        }
    }
}
