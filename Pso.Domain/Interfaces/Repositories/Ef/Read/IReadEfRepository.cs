using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Pso.Domain.Entities;

namespace Pso.Domain.Interfaces.Repositories.Ef.Read
{
    public interface IReadEfRepository<TEntity> : IDomainRepository where TEntity : Entity
    {
        Task<IQueryable<TEntity>> GetAllAsync(CancellationToken cancellationToken = default(CancellationToken));
        Task<IQueryable<TEntity>> GetAllAsync(int page, int pageSize, CancellationToken cancellationToken = default(CancellationToken));
        Task<IQueryable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken = default(CancellationToken));
        Task<TEntity> GetByIdAsync(long id, CancellationToken cancellationToken = default(CancellationToken));
        Task<TEntity> SingleAsync(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken = default(CancellationToken));
    }
}
