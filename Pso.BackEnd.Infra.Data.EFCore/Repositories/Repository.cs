using Microsoft.EntityFrameworkCore;
using PSO.BackEnd.Domain.Entities;
using PSO.BackEnd.Domain.Interfaces.Repositories.Ef.Read;
using PSO.BackEnd.Domain.Interfaces.Repositories.Ef.Write;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Pso.BackEnd.Infra.Data.EFCore.Repositories
{
    public class Repository<TEntity> : IWriteEfRepository<TEntity>, IReadEfRepository<TEntity> where TEntity : Entity
    {
        protected readonly DbContext _context;
        protected readonly DbSet<TEntity> _dbSet;

        public Repository(DbContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public async Task<TEntity> AddAsync(TEntity obj)
        {
            try
            {
                var itemResult = await _dbSet.AddAsync(obj);
                return itemResult.Entity;
            }
            catch (DbUpdateException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task DeleteAllAsync()
        {
            try
            {
                await Task.Run(() => { _dbSet.RemoveRange(_dbSet); });
            }
            catch (DbUpdateException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task DeleteAsync(Expression<Func<TEntity, bool>> expression)
        {
            try
            {
                var items = await GetAsync(expression);
                await Task.Run(() => { _dbSet.RemoveRange(items); });
            }
            catch (DbUpdateException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task DeleteAsync(TEntity obj)
        {
            try
            {
                await Task.Run(() => { _dbSet.Remove(obj); });
            }
            catch (DbUpdateException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task DeleteAsync(long id)
        {
            try
            {
                var item = await SingleAsync(o => o.Id.Equals(id));
                await Task.Run(() => { _dbSet.Remove(item); });
            }
            catch (DbUpdateException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> expression)
        {
            try
            {
                return await Task.Run(() => { return _dbSet.Any(expression); });
            }
            catch (DbUpdateException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IQueryable<TEntity>> GetAllAsync()
        {
            try
            {
                return await Task.Run(() => { return _dbSet.AsNoTracking(); });
            }
            catch (DbUpdateException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IQueryable<TEntity>> GetAllAsync(int page, int pageSize)
        {
            try
            {
                return await Task.Run(() => { return _dbSet.AsNoTracking().Skip(page).Take(pageSize); });
            }
            catch (DbUpdateException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IQueryable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> expression)
        {
            try
            {
                return await Task.Run(() => { return _dbSet.AsNoTracking().Where(expression); });
            }
            catch (DbUpdateException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<TEntity> GetByIdAsync(long id)
        {
            try
            {
                return await Task.Run(() => { return _dbSet.SingleAsync(o => o.Id.Equals(id)); });
            }
            catch (DbUpdateException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<TEntity> SingleAsync(Expression<Func<TEntity, bool>> expression)
        {
            try
            {
                return await Task.Run(() => { return _dbSet.SingleAsync(expression); });
            }
            catch (DbUpdateException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<TEntity> UpdateAsync(TEntity obj)
        {
            try
            {
                return await Task.Run(() =>
                {
                    var updated = _dbSet.Update(obj);
                    updated.State = EntityState.Modified;
                    return updated.Entity;
                });
            }
            catch (DbUpdateException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<TEntity> UpdateAsync(Expression<Func<TEntity, bool>> expression, TEntity obj)
        {
            try
            {
                var item = await SingleAsync(expression);
                _context.Entry(item).State = EntityState.Modified;
                _context.Entry(item).CurrentValues.SetValues(obj);
                return obj;
            }
            catch (DbUpdateException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}