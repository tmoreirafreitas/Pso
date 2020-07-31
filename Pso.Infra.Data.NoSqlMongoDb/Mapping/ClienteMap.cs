using MongoDB.Bson.Serialization;
using Pso.Domain.Entities;

namespace Pso.Infra.Data.NoSqlMongoDb.Mapping
{
    public class ClienteMap : MapBase<Cliente>
    {
        public override void OnBsonClassMap(BsonClassMap<Cliente> map)
        {
            map.MapMember(x => x.Cpf).SetIsRequired(true);
            map.MapMember(x => x.Endereco);
            map.MapMember(x => x.Filiacao).SetIsRequired(true);
            map.MapMember(x => x.Nascimento).SetIsRequired(true);
            map.MapMember(x => x.Nome).SetIsRequired(true);
            map.MapMember(x => x.Rg).SetIsRequired(true);
            map.MapMember(x => x.Sexo).SetIsRequired(true);
            map.MapMember(x => x.IsSPC).SetIsRequired(false);
            map.MapMember(x => x.Contatos).SetIsRequired(false);
        }
    }
}
