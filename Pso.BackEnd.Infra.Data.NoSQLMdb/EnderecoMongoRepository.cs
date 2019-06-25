using PSO.BackEnd.Domain.Entities;
using PSO.BackEnd.Domain.Interfaces.Repositories.NoSQLMdb;
using PSO.BackEnd.Domain.Interfaces.Repositories.NoSQLMdb.Read;
using PSO.BackEnd.Domain.Interfaces.Repositories.NoSQLMdb.Write;

namespace Pso.BackEnd.Infra.Data.NoSQLMdb
{
    public class EnderecoMongoRepository : MongoRepository<Endereco>, IEnderecoWriteMongoRepository, IEnderecoReadMongoRepository
    {
        public EnderecoMongoRepository(IPsoDbMongoDatabaseSettings settings) : base(settings)
        {
        }
    }
}
