using Pso.Domain.Entities;
using Pso.Domain.Interfaces.Repositories.NoSqlMongoDb.Read;
using Pso.Domain.Interfaces.Repositories.NoSqlMongoDb.Write;

namespace Pso.Infra.Data.NoSqlMongoDb.Repositories
{
    public class PedidoOculosMongoRepository : MongoRepository<PedidoOculos>, IPedidoOculosWriteMongoRepository, IPedidoOculosReadMongoRepository
    {
        public PedidoOculosMongoRepository(MongoDataContext context) : base(context)
        {
        }
    }
}
