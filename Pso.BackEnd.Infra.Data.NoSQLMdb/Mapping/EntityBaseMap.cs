using MongoDB.Bson.Serialization;
using PSO.BackEnd.Domain.Entities;

namespace Pso.BackEnd.Infra.Data.NoSQLMdb.Mapping
{
    public class EntityBaseMap : BsonClassMap<Entity>
    {
        public static void Configure()
        {
            RegisterClassMap<Entity>(map => 
            {
                map.MapMember(p => p.Id);
                map.SetIsRootClass(true);
            });
        }
    }
}
