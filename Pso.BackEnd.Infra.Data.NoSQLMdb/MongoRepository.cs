using MongoDB.Driver;
using PSO.BackEnd.Domain.Entities;
using PSO.BackEnd.Domain.Interfaces.Repositories.NoSQLMdb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
namespace Pso.BackEnd.Infra.Data.NoSQLMdb
{
    public class MongoRepository<T> : IWriteMongoRepository<T>, IReadMongoRepository<T> where T : Entity
    {
        private readonly MongoDataContext _dataContext;
        protected readonly IMongoCollection<T> _collection;

        public MongoRepository(MongoDataContext context)
        {
            _dataContext = context;
            _collection = _dataContext.MongoDatabase.GetCollection<T>(typeof(T).Name);
        }
        public Task AddAsync(T obj)
        {
            return _collection.InsertOneAsync(obj);
        }

        public Task DeleteAsync(Expression<Func<T, bool>> expression)
        {
            return _collection.DeleteOneAsync(expression);
        }

        public Task DeleteAsync(T obj)
        {
            return _collection.DeleteOneAsync(t => t.Id.Equals(obj.Id));
        }

        public Task DeleteAsync(long id)
        {
            return _collection.DeleteOneAsync(t => t.Id.Equals(id));
        }

        public Task<IEnumerable<T>> GetAllAsync()
        {
            return Task.FromResult(_collection.AsQueryable().AsEnumerable());
        }

        public Task<IEnumerable<T>> GetAllAsync(int page, int pageSize)
        {
            return Task.FromResult(_collection.AsQueryable().Skip(page).Take(pageSize).AsEnumerable());
        }

        public Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> expression)
        {
            var result = _collection.FindAsync(expression).GetAwaiter().GetResult();
            return Task.FromResult(result.ToEnumerable());
        }

        public Task<T> GetByIdAsync(long id)
        {
            var result = _collection.FindAsync(t => t.Id.Equals(id)).GetAwaiter().GetResult();
            return Task.FromResult(result.FirstOrDefault());
        }

        public Task<T> SingleAsync(Expression<Func<T, bool>> expression)
        {
            var filter = Builders<T>.Filter.Where(expression);
            var result = _collection.FindAsync(filter).GetAwaiter().GetResult().FirstOrDefault();
            return  Task.FromResult(result);
        }

        public Task<T> SingleAsync<E>(Expression<Func<T, IEnumerable<E>>> fieldCollection, Expression<Func<E, bool>> expression) where E : Entity
        {
            var filter = Builders<T>.Filter.ElemMatch(fieldCollection, expression);
            var result = _collection.Find(filter);
            return Task.FromResult(result.FirstOrDefault());
        }

        public Task UpdateAsync(T obj)
        {
            var filter = Builders<T>.Filter.Eq(s => s.Id, obj.Id);
            var options = new UpdateOptions { IsUpsert = false };
            return Task.FromResult(_collection.ReplaceOneAsync(filter, obj, options));
        }

        public Task UpdateAsync(Expression<Func<T, bool>> expression, T obj)
        {
            var options = new UpdateOptions { IsUpsert = false };
            return Task.FromResult(_collection.ReplaceOneAsync(expression, obj, options));
        }
    }
}