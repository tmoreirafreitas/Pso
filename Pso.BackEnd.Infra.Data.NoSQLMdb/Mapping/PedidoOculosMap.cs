using MongoDB.Bson.Serialization;
using PSO.BackEnd.Domain.Entities;

namespace Pso.BackEnd.Infra.Data.NoSQLMdb.Mapping
{
    public class PedidoOculosMap : BsonClassMap<PedidoOculos>
    {
        public static void Configure()
        {
            RegisterClassMap<PedidoOculos>(map =>
            {
                map.SetIgnoreExtraElements(true);
                map.MapMember(x => x.OculosId);
                map.MapMember(x => x.PedidoId);
                map.MapMember(x => x.Oculos);
                map.MapMember(x => x.Pedido);
            });
        }
    }
}
