using Pso.Domain.Entities;
using Pso.Domain.Interfaces.Repositories.NoSqlMongoDb.Read;
using Pso.Domain.Interfaces.Repositories.NoSqlMongoDb.Write;

namespace Pso.Infra.Data.NoSqlMongoDb.Repositories
{
    public class OculosMongoRepository : MongoRepository<Oculos>, IOculosWriteMongoRepository, IOculosReadMongoRepository
    {
        public OculosMongoRepository(MongoDataContext context) : base(context)
        {
        }
    }
}
