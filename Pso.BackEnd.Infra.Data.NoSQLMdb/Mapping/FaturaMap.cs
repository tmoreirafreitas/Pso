using MongoDB.Bson.Serialization;
using PSO.BackEnd.Domain.Entities;

namespace Pso.BackEnd.Infra.Data.NoSQLMdb.Mapping
{
    public class FaturaMap  : BsonClassMap<Fatura>
    {
        public static void Configure()
        {
            RegisterClassMap<Fatura>(map =>
            {
                map.SetIgnoreExtraElements(true);
                map.MapMember(x => x.DataPagamento).SetIsRequired(true);
                map.MapMember(x => x.FormaPagamento).SetIsRequired(true);
                map.MapMember(x => x.NumeroParcelas);
                map.MapMember(x => x.PedidoId).SetIsRequired(true);
                map.MapMember(x => x.Sinal).SetIsRequired(true);
                map.MapMember(x => x.Total).SetIsRequired(true);
                map.MapMember(x => x.Valor).SetIsRequired(true);
            });
        }
    }
}
