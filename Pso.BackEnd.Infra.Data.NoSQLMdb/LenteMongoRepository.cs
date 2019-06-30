using Microsoft.Extensions.Configuration;
using PSO.BackEnd.Domain.Entities;
using PSO.BackEnd.Domain.Interfaces.Repositories.NoSQLMdb.Read;
using PSO.BackEnd.Domain.Interfaces.Repositories.NoSQLMdb.Write;

namespace Pso.BackEnd.Infra.Data.NoSQLMdb
{
    public class LenteMongoRepository : MongoRepository<Lente>, ILenteWriteMongoRepository, ILenteReadMongoRepository
    {
        public LenteMongoRepository(IConfiguration configuration) : base(configuration)
        {
        }
    }
}
