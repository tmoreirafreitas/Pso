using MongoDB.Bson.Serialization;
using Pso.Domain.Entities;

namespace Pso.Infra.Data.NoSqlMongoDb.Mapping
{
    public class ParcelaMap : MapBase<Parcela>
    {
        public override void OnBsonClassMap(BsonClassMap<Parcela> map)
        {
            map.MapMember(x => x.DataPagamento).SetIsRequired(true);
            map.MapMember(x => x.DataVencimento).SetIsRequired(true);
            map.MapMember(x => x.FaturaId).SetIsRequired(true);
            map.MapMember(x => x.Numero).SetIsRequired(true);
            map.MapMember(x => x.Recebido).SetIsRequired(true);
            map.MapMember(x => x.Valor).SetIsRequired(true);
        }
    }
}
