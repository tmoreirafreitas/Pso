using System;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Pso.Domain.Entities;

namespace Pso.Domain.Interfaces.Repositories.NoSqlMongoDb
{
    public interface IWriteMongoRepository<TEntity> : IDomainRepository where TEntity : Entity
    {
        Task UpdateAsync(TEntity obj);
        Task UpdateAsync(Expression<Func<TEntity, bool>> expression, TEntity obj);
        Task AddAsync(TEntity obj, CancellationToken cancellationToken = default(CancellationToken));
        Task DeleteAsync(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken = default(CancellationToken));
        Task DeleteAsync(TEntity obj, CancellationToken cancellationToken = default(CancellationToken));
        Task DeleteAsync(long id, CancellationToken cancellationToken = default(CancellationToken));

    }
}
