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
        private readonly IMongoCollection<T> DbSet;

        public MongoRepository(IMongoDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            DbSet = database.GetCollection<T>(typeof(T).Name);
        }
        public async Task AddAsync(T obj)
        {
            await DbSet.InsertOneAsync(obj);
        }

        public async Task DeleteAsync(Expression<Func<T, bool>> expression)
        {
            await DbSet.DeleteOneAsync(expression);
        }

        public async Task DeleteAsync(T obj)
        {
            await DbSet.DeleteOneAsync(t => t.Id.Equals(obj.Id));
        }

        public async Task DeleteAsync(long id)
        {
            await DbSet.DeleteOneAsync(t => t.Id.Equals(id));
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await Task.Run(() =>
            {
                return DbSet.AsQueryable().ToList();
            });
        }

        public async Task<IEnumerable<T>> GetAllAsync(int page, int pageSize)
        {
            return await Task.Run(() =>
            {
                return DbSet.AsQueryable().Skip(page).Take(pageSize).ToList();
            });
        }

        public async Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> expression)
        {
            var result = await DbSet.FindAsync(expression);
            return result.ToList();
        }

        public async Task<T> GetByIdAsync(long id)
        {
            var result = await DbSet.FindAsync(t => t.Id.Equals(id));
            return await result.FirstOrDefaultAsync();
        }

        public async Task<T> SingleAsync(Expression<Func<T, bool>> expression)
        {
            var result = await DbSet.FindAsync(expression);
            return await result.SingleOrDefaultAsync();
        }

        public async Task UpdateAsync(T obj)
        {
            var filter = Builders<T>.Filter.Eq(s => s.Id, obj.Id);
            var options = new UpdateOptions { IsUpsert = false };
            await DbSet.ReplaceOneAsync(filter, obj, options);
        }

        public async Task UpdateAsync(Expression<Func<T, bool>> expression, T obj)
        {
            var options = new UpdateOptions { IsUpsert = false };
            await DbSet.ReplaceOneAsync(expression, obj, options);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
