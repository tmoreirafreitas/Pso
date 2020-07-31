using MongoDB.Bson.Serialization;
using Pso.Domain.Entities;

namespace Pso.Infra.Data.NoSqlMongoDb.Mapping
{
    public class ContatoMap : MapBase<Contato>
    {
        public override void OnBsonClassMap(BsonClassMap<Contato> map)
        {
            map.MapMember(x => x.Nome).SetIsRequired(true);
            map.MapMember(x => x.Telefone).SetIsRequired(true);
            map.MapMember(x => x.ClienteId).SetIsRequired(false);
            map.MapMember(x => x.Email).SetIsRequired(true);
            map.MapMember(x => x.Cliente);
        }
    }
}
