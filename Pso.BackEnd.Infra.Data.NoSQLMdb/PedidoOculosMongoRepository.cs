using Microsoft.Extensions.Options;
using PSO.BackEnd.Domain.Entities;
using PSO.BackEnd.Domain.Interfaces.Repositories.NoSQLMdb.Read;
using PSO.BackEnd.Domain.Interfaces.Repositories.NoSQLMdb.Write;

namespace Pso.BackEnd.Infra.Data.NoSQLMdb
{
    public class PedidoOculosMongoRepository : MongoRepository<PedidoOculos>, IPedidoOculosWriteMongoRepository, IPedidoOculosReadMongoRepository
    {
        public PedidoOculosMongoRepository(MongoDataContext context) : base(context)
        {
        }
    }
}
