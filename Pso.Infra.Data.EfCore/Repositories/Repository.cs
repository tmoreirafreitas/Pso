using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Pso.Domain.Entities;
using Pso.Domain.Interfaces.Repositories.Ef.Read;
using Pso.Domain.Interfaces.Repositories.Ef.Write;

namespace Pso.Infra.Data.EfCore.Repositories
{
    public class Repository<TEntity> : IWriteEfRepository<TEntity>, IReadEfRepository<TEntity> where TEntity : Entity
    {
        protected readonly DbContext Context;
        protected readonly DbSet<TEntity> DbSet;

        public Repository(DbContext context)
        {
            Context = context;
            DbSet = Context.Set<TEntity>();
        }

        public async Task<TEntity> AddAsync(TEntity item, CancellationToken cancellationToken = default(CancellationToken))
        {
            var itemAdded = (await DbSet.AddAsync(item, cancellationToken)).Entity;
            return itemAdded;
        }

        public Task AddRangeAsync(ICollection<TEntity> items, CancellationToken cancellationToken = default(CancellationToken))
        {
            DbSet.AddRangeAsync(items, cancellationToken);
            return Task.CompletedTask;
        }

        public Task DeleteAllAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            cancellationToken.ThrowIfCancellationRequested();
            DbSet.RemoveRange(DbSet);
            return Task.CompletedTask;
        }

        public async Task DeleteAsync(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken = default(CancellationToken))
        {
            var items = await GetAsync(expression, cancellationToken);
            DbSet.RemoveRange(items);
        }

        public Task DeleteAsync(TEntity item, CancellationToken cancellationToken = default(CancellationToken))
        {
            cancellationToken.ThrowIfCancellationRequested();
            DbSet.Remove(item);
            return Task.CompletedTask;
        }

        public async Task DeleteAsync(long id, CancellationToken cancellationToken = default(CancellationToken))
        {
            var item = await DbSet.AsNoTracking().FirstOrDefaultAsync(o => o.Id.Equals(id), cancellationToken);
            DbSet.Remove(item);
        }

        public Task<IQueryable<TEntity>> GetAllAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            cancellationToken.ThrowIfCancellationRequested();
            return Task.FromResult(DbSet.AsNoTracking());
        }

        public Task<IQueryable<TEntity>> GetAllAsync(int page, int pageSize, CancellationToken cancellationToken = default(CancellationToken))
        {
            cancellationToken.ThrowIfCancellationRequested();
            return Task.FromResult(DbSet.AsNoTracking().Skip(page).Take(pageSize));
        }

        public Task<IQueryable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken = default(CancellationToken))
        {
            cancellationToken.ThrowIfCancellationRequested();
            return Task.FromResult(DbSet.AsNoTracking().Where(expression));
        }

        public Task<TEntity> GetByIdAsync(long id, CancellationToken cancellationToken = default(CancellationToken))
        {
            return DbSet.AsNoTracking().FirstOrDefaultAsync(o => o.Id.Equals(id), cancellationToken);
        }

        public Task<TEntity> SingleAsync(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken = default(CancellationToken))
        {
            return DbSet.AsNoTracking().SingleOrDefaultAsync(expression, cancellationToken);
        }

        public Task<TEntity> Update(TEntity item)
        {
            var updated = DbSet.Update(item);
            return Task.FromResult(updated.Entity);
        }
    }
}