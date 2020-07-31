using Pso.Domain.Entities;

namespace Pso.Domain.Core
{
    public class UpdateCommand<TEntity> : Command<TEntity>, ICommand<ResultCommand> where TEntity : Entity
    {
        public long Id { get; }

        public UpdateCommand(long id)
        {
            Id = id;
        }
    }
}