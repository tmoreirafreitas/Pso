using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;
using Pso.Domain.Entities;

namespace Pso.Infra.Data.NoSqlMongoDb.Mapping
{
    public class EntityMap : BsonClassMap<Entity>
    {
        public static void Configure()
        {
            RegisterClassMap<Entity>(map =>
            {
                map.MapMember(p => p.Id);
                map.MapIdField(x => x.ObjectId).SetIdGenerator(StringObjectIdGenerator.Instance);
                map.SetIsRootClass(true);
            });
        }
    }
}
