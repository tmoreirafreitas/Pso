using Pso.Domain.Entities;
using Pso.Domain.Interfaces.Repositories.NoSqlMongoDb.Read;
using Pso.Domain.Interfaces.Repositories.NoSqlMongoDb.Write;

namespace Pso.Infra.Data.NoSqlMongoDb.Repositories
{
    public class EnderecoMongoRepository : MongoRepository<Endereco>, IEnderecoWriteMongoRepository, IEnderecoReadMongoRepository
    {
        public EnderecoMongoRepository(MongoDataContext context) : base(context)
        {
        }
    }
}
