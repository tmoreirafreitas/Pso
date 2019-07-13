using MongoDB.Bson.Serialization;
using PSO.BackEnd.Domain.Entities;

namespace Pso.BackEnd.Infra.Data.NoSQLMdb.Mapping
{
    public class ParcelaMap : BsonClassMap<Parcela>
    {
        public static void Configure()
        {
            RegisterClassMap<Parcela>(map => 
            {
                map.SetIgnoreExtraElements(true);
                map.MapMember(x => x.DataPagamento).SetIsRequired(true);
                map.MapMember(x => x.DataVencimento).SetIsRequired(true);
                map.MapMember(x => x.FaturaId).SetIsRequired(true);
                map.MapMember(x => x.Numero).SetIsRequired(true);
                map.MapMember(x => x.Recebido).SetIsRequired(true);
                map.MapMember(x => x.Valor).SetIsRequired(true);
            });
        }
    }
}
