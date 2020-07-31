using MongoDB.Bson.Serialization;
using Pso.Domain.Entities;

namespace Pso.Infra.Data.NoSqlMongoDb.Mapping
{
    public class FaturaMap  : MapBase<Fatura>
    {
        public override void OnBsonClassMap(BsonClassMap<Fatura> map)
        {
            map.MapMember(x => x.DataPagamento).SetIsRequired(true);
            map.MapMember(x => x.FormaPagamento).SetIsRequired(true);
            map.MapMember(x => x.NumeroParcelas);
            map.MapMember(x => x.PedidoId).SetIsRequired(true);
            map.MapMember(x => x.Parcelas);
            map.MapMember(x => x.Sinal).SetIsRequired(true);
            map.MapMember(x => x.Total).SetIsRequired(true);
            map.MapMember(x => x.Valor).SetIsRequired(true);
        }
    }
}
