using MongoDB.Bson.Serialization;
using Pso.Domain.Entities;

namespace Pso.Infra.Data.NoSqlMongoDb.Mapping
{
    public class PedidoOculosMap : MapBase<PedidoOculos>
    {
        public override void OnBsonClassMap(BsonClassMap<PedidoOculos> map)
        {
            map.MapMember(x => x.OculosId);
            map.MapMember(x => x.PedidoId);
            map.MapMember(x => x.Oculos);
            map.MapMember(x => x.Pedido);
        }
    }
}
