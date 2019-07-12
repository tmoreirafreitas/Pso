using System;
using MongoDB.Bson.Serialization;
using PSO.BackEnd.Domain.Entities;

namespace Pso.BackEnd.Infra.Data.NoSQLMdb.Mapping
{
    public class ContatoMap : BsonClassMap<Contato>
    {
        public Type ValueType => throw new NotImplementedException();

        public static void Configure()
        {
            RegisterClassMap<Contato>(map =>
            {
                map.SetIgnoreExtraElements(true);
                map.MapMember(x => x.Nome).SetIsRequired(true);
                map.MapMember(x => x.Telefone).SetIsRequired(true);
                map.MapMember(x => x.ClienteId).SetIsRequired(false);
                map.MapMember(x => x.Email).SetIsRequired(true);
            });
        }
    }
}
