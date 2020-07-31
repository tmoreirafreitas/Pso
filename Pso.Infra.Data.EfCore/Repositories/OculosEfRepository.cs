using Microsoft.EntityFrameworkCore;
using Pso.Domain.Entities;
using Pso.Domain.Interfaces.Repositories.Ef.Read;
using Pso.Domain.Interfaces.Repositories.Ef.Write;

namespace Pso.Infra.Data.EfCore.Repositories
{
    public class OculosEfRepository : Repository<Oculos>, IOculosWriteEfRepository, IOculosReadEfRepository
    {
        public OculosEfRepository(DbContext context) : base(context)
        {
        }
    }
}
