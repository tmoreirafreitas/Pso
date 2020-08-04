using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Pso.Domain.Entities;

namespace Pso.Domain.Interfaces.Repositories.NoSqlMongoDb
{
    public interface IReadMongoRepository<TEntity> : IDomainRepository where TEntity : Entity
    {
        Task<ICollection<TEntity>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<ICollection<TEntity>> GetAllAsync(int page, int pageSize, CancellationToken cancellationToken = default);
        Task<ICollection<TEntity>> GetAsync(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken = default);
        Task<TEntity> GetByIdAsync(long id, CancellationToken cancellationToken = default);
        Task<TEntity> SingleAsync(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken = default);
        Task<TEntity> SingleAsync<TE>(Expression<Func<TEntity, IEnumerable<TE>>> fieldCollection, Expression<Func<TE, bool>> expression, CancellationToken cancellationToken = default) where TE : Entity;
    }
}
