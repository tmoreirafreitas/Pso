using Pso.Domain.Entities;
using Pso.Domain.Interfaces.Repositories.NoSqlMongoDb.Read;
using Pso.Domain.Interfaces.Repositories.NoSqlMongoDb.Write;

namespace Pso.Infra.Data.NoSqlMongoDb.Repositories
{
    public class ContatoMongoRepository : MongoRepository<Contato>, IContatoWriteMongoRepository, IContatoReadMongoRepository
    {
        public ContatoMongoRepository(MongoDataContext context) : base(context)
        {
        }
    }
}
