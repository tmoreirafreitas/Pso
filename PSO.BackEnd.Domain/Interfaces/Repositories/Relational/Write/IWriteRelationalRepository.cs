using PSO.BackEnd.Domain.Entities;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PSO.BackEnd.Domain.Interfaces.Repositories.Relational.Write
{
    public interface IWriteRelationalRepository<TEntity> where TEntity : Entity
    {
        Task<TEntity> UpdateAsync(TEntity obj);
        Task<TEntity> UpdateAsync(Expression<Func<TEntity, bool>> expression, TEntity obj);
        Task<TEntity> AddAsync(TEntity obj);
        Task DeleteAsync(Expression<Func<TEntity, bool>> expression);        
        Task DeleteAsync(TEntity obj);
        Task DeleteAsync(long id);
        Task DeleteAllAsync();
    }
}
