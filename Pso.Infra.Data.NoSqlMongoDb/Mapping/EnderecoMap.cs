using MongoDB.Bson.Serialization;
using Pso.Domain.Entities;

namespace Pso.Infra.Data.NoSqlMongoDb.Mapping
{
    public class EnderecoMap : MapBase<Endereco>
    {
        public override void OnBsonClassMap(BsonClassMap<Endereco> map)
        {
            map.MapMember(x => x.Bairro).SetIsRequired(true);
            map.MapMember(x => x.Cep).SetIsRequired(true);
            map.MapMember(x => x.Cidade).SetIsRequired(true);
            map.MapMember(x => x.ClienteId).SetIsRequired(false);
            map.MapMember(x => x.Complemento).SetIsRequired(false);
            map.MapMember(x => x.Estado).SetIsRequired(true);
            map.MapMember(x => x.Logradouro).SetIsRequired(true);
            map.MapMember(x => x.Numero).SetIsRequired(false);
        }
    }
}
