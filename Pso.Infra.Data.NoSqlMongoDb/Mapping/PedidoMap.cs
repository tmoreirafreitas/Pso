using MongoDB.Bson.Serialization;
using Pso.Domain.Entities;

namespace Pso.Infra.Data.NoSqlMongoDb.Mapping
{
    public class PedidoMap : MapBase<Pedido>
    {
        public override void OnBsonClassMap(BsonClassMap<Pedido> map)
        {
            map.MapMember(x => x.ClienteId).SetIsRequired(true);
            map.MapMember(x => x.DataEntrega).SetIsRequired(true);
            map.MapMember(x => x.DataSolicitacao).SetIsRequired(true);
            map.MapMember(x => x.FaturaId).SetIsRequired(true);
            map.MapMember(x => x.Fatura);
            map.MapMember(x => x.Medico).SetIsRequired(true);
            map.MapMember(x => x.Obs).SetIsRequired(false);
            map.MapMember(x => x.Preco).SetIsRequired(true);
            map.MapMember(x => x.Servico).SetIsRequired(true);
        }
    }
}
