using PSO.BackEnd.Domain.Entities;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PSO.BackEnd.Domain.Interfaces.Repositories.NoSQLMdb
{
    public interface IWriteMongoRepository<TEntity> where TEntity : Entity
    {
        Task UpdateAsync(TEntity obj);
        Task UpdateAsync(Expression<Func<TEntity, bool>> expression, TEntity obj);
        Task AddAsync(TEntity obj);
        Task DeleteAsync(Expression<Func<TEntity, bool>> expression);
        Task DeleteAsync(TEntity obj);
        Task DeleteAsync(long id);
    }
}
