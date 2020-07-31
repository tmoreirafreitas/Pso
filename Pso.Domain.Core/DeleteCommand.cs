using MediatR;
using Pso.Domain.Entities;

namespace Pso.Domain.Core
{
    public class DeleteCommand<TEntity> : Command<TEntity>, ICommand<ResultCommand> where TEntity : Entity
    {
        public long Id { get; }

        public DeleteCommand(long id)
        {
            Id = id;
        }
    }
}
