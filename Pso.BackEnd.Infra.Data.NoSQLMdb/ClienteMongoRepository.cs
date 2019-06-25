using PSO.BackEnd.Domain.Entities;
using PSO.BackEnd.Domain.Interfaces.Repositories.NoSQLMdb;
using PSO.BackEnd.Domain.Interfaces.Repositories.NoSQLMdb.Read;
using PSO.BackEnd.Domain.Interfaces.Repositories.NoSQLMdb.Write;

namespace Pso.BackEnd.Infra.Data.NoSQLMdb
{
    public class ClienteMongoRepository : MongoRepository<Cliente>, IClienteWriteMongoRepository, IClienteReadMongoRepository
    {
        public ClienteMongoRepository(IPsoDbMongoDatabaseSettings settings) : base(settings)
        {
        }
    }
}
