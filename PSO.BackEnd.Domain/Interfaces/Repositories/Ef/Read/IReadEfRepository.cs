using PSO.BackEnd.Domain.Entities;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PSO.BackEnd.Domain.Interfaces.Repositories.Ef.Read
{
    public interface IReadEfRepository<TEntity> where TEntity : Entity
    {
        IQueryable<TEntity> GetAll();
        IQueryable<TEntity> GetAll(int page, int pageSize);
        IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> expression);
        TEntity GetById(long id);
        TEntity Single(Expression<Func<TEntity, bool>> expression);
        bool Exists(Expression<Func<TEntity, bool>> expression);
    }
}
