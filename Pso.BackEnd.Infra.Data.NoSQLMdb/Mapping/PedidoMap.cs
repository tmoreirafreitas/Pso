using MongoDB.Bson.Serialization;
using PSO.BackEnd.Domain.Entities;

namespace Pso.BackEnd.Infra.Data.NoSQLMdb.Mapping
{
    public class PedidoMap : BsonClassMap<Pedido>
    {
        public static void Configure()
        {
            RegisterClassMap<Pedido>(map =>
            {
                map.SetIgnoreExtraElements(true);
                map.MapMember(x => x.ClienteId).SetIsRequired(true);
                map.MapMember(x => x.DataEntrega).SetIsRequired(true);
                map.MapMember(x => x.DataSolicitacao).SetIsRequired(true);
                map.MapMember(x => x.FaturaId).SetIsRequired(true);
                map.MapMember(x => x.Medico).SetIsRequired(true);
                map.MapMember(x => x.Obs).SetIsRequired(false);
                map.MapMember(x => x.Preco).SetIsRequired(true);
                map.MapMember(x => x.Servico).SetIsRequired(true);
            });
        }
    }
}
