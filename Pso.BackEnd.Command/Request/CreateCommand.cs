using MediatR;
using PSO.BackEnd.Domain.Entities;

namespace Pso.BackEnd.Command.Request
{
    public class CreateCommand<T> : Command<T>, IRequest<bool> where T : Entity
    {
        public CreateCommand(T item) : base(item)
        {
        }
    }
}
