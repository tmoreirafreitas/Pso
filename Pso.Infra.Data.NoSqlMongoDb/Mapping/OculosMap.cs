using MongoDB.Bson.Serialization;
using Pso.Domain.Entities;

namespace Pso.Infra.Data.NoSqlMongoDb.Mapping
{
    public class OculosMap : MapBase<Oculos>
    {
        public override void OnBsonClassMap(BsonClassMap<Oculos> map)
        {
            map.MapMember(x => x.Adicao).SetIsRequired(true);
            map.MapMember(x => x.ALT).SetIsRequired(true);
            map.MapMember(x => x.Cor).SetIsRequired(true);
            map.MapMember(x => x.DP).SetIsRequired(true);
            map.MapMember(x => x.PedidoOculosId).SetIsRequired(true);
        }
    }
}
