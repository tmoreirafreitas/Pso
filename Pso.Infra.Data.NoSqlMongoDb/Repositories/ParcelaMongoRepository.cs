using Pso.Domain.Entities;
using Pso.Domain.Interfaces.Repositories.NoSqlMongoDb.Read;
using Pso.Domain.Interfaces.Repositories.NoSqlMongoDb.Write;

namespace Pso.Infra.Data.NoSqlMongoDb.Repositories
{
    public class ParcelaMongoRepository : MongoRepository<Parcela>, IParcelaWriteMongoRepository, IParcelaReadMongoRepository
    {
        public ParcelaMongoRepository(MongoDataContext context) : base(context)
        {
        }
    }
}
