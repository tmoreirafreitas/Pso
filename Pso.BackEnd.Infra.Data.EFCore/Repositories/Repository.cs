using Microsoft.EntityFrameworkCore;
using PSO.BackEnd.Domain.Entities;
using PSO.BackEnd.Domain.Interfaces.Repositories.Ef.Read;
using PSO.BackEnd.Domain.Interfaces.Repositories.Ef.Write;
using System;
using System.Linq;
using System.Linq.Expressions;

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

        public TEntity Add(TEntity obj)
        {
            try
            {
                var itemResult = _dbSet.Add(obj);
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

        public void DeleteAll()
        {
            try
            {
                _dbSet.RemoveRange(_dbSet);
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

        public void Delete(Expression<Func<TEntity, bool>> expression)
        {
            try
            {
                var items = Get(expression);
                _dbSet.RemoveRange(items);
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

        public void Delete(TEntity obj)
        {
            try
            {
                _dbSet.Remove(obj);
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

        public void Delete(long id)
        {
            try
            {
                var item = _dbSet.FirstOrDefault(o => o.Id.Equals(id));
                _dbSet.Remove(item);
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

        public bool Exists(Expression<Func<TEntity, bool>> expression)
        {
            try
            {
                return _dbSet.Any(expression);
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

        public IQueryable<TEntity> GetAll()
        {
            try
            {
                return _dbSet.AsNoTracking();
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

        public IQueryable<TEntity> GetAll(int page, int pageSize)
        {
            try
            {
                return _dbSet.AsNoTracking().Skip(page).Take(pageSize);
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

        public IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> expression)
        {
            try
            {
                return _dbSet.AsNoTracking().Where(expression);
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

        public TEntity GetById(long id)
        {
            try
            {
                return _dbSet.FirstOrDefault(o => o.Id.Equals(id));
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

        public TEntity Single(Expression<Func<TEntity, bool>> expression)
        {
            try
            {
                return _dbSet.SingleOrDefault(expression);
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

        public TEntity Update(TEntity obj)
        {
            try
            {
                var updated = _dbSet.Update(obj);
                updated.State = EntityState.Modified;
                return updated.Entity;
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

        public TEntity Update(Expression<Func<TEntity, bool>> expression, TEntity obj)
        {
            try
            {
                var item = _dbSet.SingleOrDefault(expression);
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