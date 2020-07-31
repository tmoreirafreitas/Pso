using MongoDB.Bson.Serialization;
using Pso.Domain.Entities;

namespace Pso.Infra.Data.NoSqlMongoDb.Mapping
{
    public abstract class MapBase<TEntity> : BsonClassMap<TEntity> where TEntity : Entity
    {
        public void Configure()
        {
            RegisterClassMap<TEntity>(map =>
            {
                map.AutoMap();
                map.SetIgnoreExtraElements(true);
                OnBsonClassMap(map);
            });
        }

        public abstract void OnBsonClassMap(BsonClassMap<TEntity> map);
    }
}