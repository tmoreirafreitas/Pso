using MongoDB.Bson.Serialization;
using Pso.Domain.Entities;

namespace Pso.Infra.Data.NoSqlMongoDb.Mapping
{
    public class LenteMap : MapBase<Lente>
    {
        public override void OnBsonClassMap(BsonClassMap<Lente> map)
        {
            map.MapMember(x => x.Cyl);
            map.MapMember(x => x.Eixo);
            map.MapMember(x => x.Grau);
            map.MapMember(x => x.OculosId);
            map.MapMember(x => x.LenteType);
        }
    }
}
