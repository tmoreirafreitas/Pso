using MongoDB.Bson.Serialization;
using PSO.BackEnd.Domain.Entities;

namespace Pso.BackEnd.Infra.Data.NoSQLMdb.Mapping
{
    public class EnderecoMap : BsonClassMap<Endereco>
    {
        public static void Configure()
        {
            RegisterClassMap<Endereco>(map =>
            {
                map.SetIgnoreExtraElements(true);
                map.MapMember(x => x.Bairro).SetIsRequired(true); ;
                map.MapMember(x => x.Cep).SetIsRequired(true);
                map.MapMember(x => x.Cidade).SetIsRequired(true);
                map.MapMember(x => x.ClienteId).SetIsRequired(false);
                map.MapMember(x => x.Complemento).SetIsRequired(false);
                map.MapMember(x => x.Estado).SetIsRequired(true);
                map.MapMember(x => x.Logradouro).SetIsRequired(true);
                map.MapMember(x => x.Numero).SetIsRequired(false);
            });
        }
    }
}
