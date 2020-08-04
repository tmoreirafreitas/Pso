using MediatR;
using Pso.Domain.Entities;

namespace Pso.Domain.Core
{
    public class DeleteCommand : Command
    {
        public long Id { get; }

        public DeleteCommand(long id)
        {
            Id = id;
        }
    }

    public class DeleteCommand<TEntity> : Command<TEntity> where TEntity : Entity
    {
        public long Id { get; }

        public DeleteCommand(long id)
        {
            Id = id;
        }
    }
}
