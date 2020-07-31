using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Pso.Domain.Entities;

namespace Pso.Domain.Interfaces.Repositories.Ef.Write
{
    public interface IWriteEfRepository<TEntity> : IDomainRepository where TEntity : Entity
    {
        Task<TEntity> Update(TEntity item);
        Task<TEntity> AddAsync(TEntity item, CancellationToken cancellationToken = default(CancellationToken));
        Task AddRangeAsync(ICollection<TEntity> item, CancellationToken cancellationToken = default(CancellationToken));
        Task DeleteAsync(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken = default(CancellationToken));
        Task DeleteAsync(TEntity item, CancellationToken cancellationToken = default(CancellationToken));
        Task DeleteAsync(long id, CancellationToken cancellationToken = default(CancellationToken));
        Task DeleteAllAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}
