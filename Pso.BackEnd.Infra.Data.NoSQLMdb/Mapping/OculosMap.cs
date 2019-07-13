using MongoDB.Bson.Serialization;
using PSO.BackEnd.Domain.Entities;

namespace Pso.BackEnd.Infra.Data.NoSQLMdb.Mapping
{
    public class OculosMap : BsonClassMap<Oculos>
    {
        public static void Configure()
        {
            RegisterClassMap<Oculos>(map =>
            {
                map.SetIgnoreExtraElements(true);
                map.MapMember(x => x.Adicao).SetIsRequired(true);
                map.MapMember(x => x.ALT).SetIsRequired(true);
                map.MapMember(x => x.Cor).SetIsRequired(true);
                map.MapMember(x => x.DP).SetIsRequired(true);
                map.MapMember(x => x.PedidoOculosId).SetIsRequired(true);
            });
        }
    }
}
