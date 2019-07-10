using PSO.BackEnd.Domain.Entities;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PSO.BackEnd.Domain.Interfaces.Repositories.Ef.Write
{
    public interface IWriteEfRepository<TEntity> where TEntity : Entity
    {
        TEntity Update(TEntity obj);
        TEntity Update(Expression<Func<TEntity, bool>> expression, TEntity obj);
        TEntity Add(TEntity obj);
        void Delete(Expression<Func<TEntity, bool>> expression);        
        void Delete(TEntity obj);
        void Delete(long id);
        void DeleteAll();
    }
}
