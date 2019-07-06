using Microsoft.Extensions.Options;
using PSO.BackEnd.Domain.Entities;
using PSO.BackEnd.Domain.Interfaces.Repositories.NoSQLMdb.Read;
using PSO.BackEnd.Domain.Interfaces.Repositories.NoSQLMdb.Write;

namespace Pso.BackEnd.Infra.Data.NoSQLMdb
{
    public class PedidoMongoRepository : MongoRepository<Pedido>, IPedidoWriteMongoRepository, IPedidoReadMongoRepository
    {
        public PedidoMongoRepository(MongoDataContext context) : base(context)
        {
        }
    }
}
