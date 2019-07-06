using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using PSO.BackEnd.Domain.Entities;

namespace Pso.BackEnd.Infra.Data.NoSQLMdb.Mapping
{
    public class ClienteMap : BsonClassMap<Cliente>
    {
        public static void Configure()
        {
            RegisterClassMap<Cliente>(map => 
            {
                //map.AutoMap();
                map.SetIgnoreExtraElements(true);                
                map.MapMember(x => x.Cpf).SetIsRequired(true);
                map.MapMember(x => x.Contatos).SetIsRequired(false);
                map.MapMember(x => x.Endereco);
                map.MapMember(x => x.Filiacao).SetIsRequired(true);
                map.MapMember(x => x.Nascimento).SetIsRequired(true);
                map.MapMember(x => x.Nome).SetIsRequired(true);
                map.MapMember(x => x.Rg).SetIsRequired(true);
                map.MapMember(x => x.Sexo).SetIsRequired(true);
            });            
        }
    }
}
