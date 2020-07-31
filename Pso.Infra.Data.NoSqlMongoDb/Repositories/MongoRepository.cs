using MongoDB.Bson;
using MongoDB.Driver;
using Pso.Domain.Entities;
using Pso.Domain.Interfaces.Repositories.NoSqlMongoDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Pso.Infra.Data.NoSqlMongoDb.Repositories
{
    public class MongoRepository<T> : IWriteMongoRepository<T>, IReadMongoRepository<T> where T : Entity
    {
        protected readonly IMongoCollection<T> Collection;

        public MongoRepository(MongoDataContext dataContext)
        {
            Collection = dataContext.MongoDatabase.GetCollection<T>(typeof(T).Name);
        }

        public Task AddAsync(T obj, CancellationToken cancellationToken = default(CancellationToken))
        {
            Collection.InsertOneAsync(obj, cancellationToken: cancellationToken).ConfigureAwait(false);
            return Task.CompletedTask;
        }

        public Task DeleteAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default(CancellationToken))
        {
            Collection.DeleteOneAsync(expression, cancellationToken).ConfigureAwait(false);
            return Task.CompletedTask;
        }

        public Task DeleteAsync(T obj, CancellationToken cancellationToken = default(CancellationToken))
        {
            Collection.DeleteOneAsync(t => t.Id.Equals(obj.Id), cancellationToken).ConfigureAwait(false);
            return Task.CompletedTask;
        }

        public Task DeleteAsync(long id, CancellationToken cancellationToken = default(CancellationToken))
        {
            Collection.DeleteOneAsync(t => t.Id.Equals(id), cancellationToken).ConfigureAwait(false);
            return Task.CompletedTask;
        }

        public async Task<ICollection<T>> GetAllAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var filter = Builders<T>.Filter.Empty;
            var items = await Collection.Find(filter).ToListAsync(cancellationToken).ConfigureAwait(false);
            return items;
        }

        public async Task<ICollection<T>> GetAllAsync(int page, int pageSize, CancellationToken cancellationToken = default(CancellationToken))
        {
            var filter = Builders<T>.Filter.Empty;
            var items = await Collection.Find(filter).ToListAsync(cancellationToken).ConfigureAwait(false);
            return items.Skip(page).Take(pageSize).ToList();
        }

        public async Task<ICollection<T>> GetAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default(CancellationToken))
        {
            var filter = Builders<T>.Filter.Where(expression);
            var items = await Collection.Find(filter).ToListAsync(cancellationToken).ConfigureAwait(false);
            return items;
        }

        public async Task<T> GetByIdAsync(long id, CancellationToken cancellationToken = default(CancellationToken))
        {
            var filter = Builders<T>.Filter.Where(t => t.Id.Equals(id));
            var item = await Collection.FindAsync(filter, cancellationToken: cancellationToken).ConfigureAwait(false);
            return item.FirstOrDefault();
        }

        public async Task<T> SingleAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default(CancellationToken))
        {
            var filter = Builders<T>.Filter.Where(expression);
            var item = await Collection.FindAsync(filter, cancellationToken: cancellationToken).ConfigureAwait(false);
            return item.FirstOrDefault();
        }

        public async Task<T> SingleAsync<TE>(Expression<Func<T, IEnumerable<TE>>> fieldCollection, Expression<Func<TE, bool>> expression,
            CancellationToken cancellationToken = default(CancellationToken)) where TE : Entity
        {
            var filter = Builders<T>.Filter.ElemMatch(fieldCollection, expression);
            var item = await Collection.FindAsync(filter, cancellationToken: cancellationToken).ConfigureAwait(false);
            return item.FirstOrDefault();
        }

        public Task UpdateAsync(T obj)
        {
            var filter = Builders<T>.Filter.Eq(s => s.Id, obj.Id);
            var update = new BsonDocument("$set", obj.ToBsonDocument());
            var options = new UpdateOptions { IsUpsert = false };
            return Task.FromResult(Collection.UpdateOne(filter, update, options));
        }

        public Task UpdateAsync(Expression<Func<T, bool>> expression, T obj)
        {
            var options = new UpdateOptions { IsUpsert = false };
            return Task.FromResult(Collection.UpdateOne(expression, obj.ToBsonDocument(), options));
        }
    }
}