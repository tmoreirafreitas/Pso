using MongoDB.Bson.Serialization;
using PSO.BackEnd.Domain.Entities;

namespace Pso.BackEnd.Infra.Data.NoSQLMdb.Mapping
{
    public class LenteMap : BsonClassMap<Lente>
    {
        public static void Configure()
        {
            RegisterClassMap<Lente>(map =>
            {
                map.SetIgnoreExtraElements(true);
                map.MapMember(x => x.Cyl);
                map.MapMember(x => x.Eixo);
                map.MapMember(x => x.Grau);
                map.MapMember(x => x.OculosId);
                map.MapMember(x => x.LenteType);
            });
        }
    }
}
