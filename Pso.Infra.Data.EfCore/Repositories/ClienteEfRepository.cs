using Microsoft.EntityFrameworkCore;
using Pso.Domain.Entities;
using Pso.Domain.Interfaces.Repositories.Ef.Read;
using Pso.Domain.Interfaces.Repositories.Ef.Write;

namespace Pso.Infra.Data.EfCore.Repositories
{
    public class ClienteEfRepository : Repository<Cliente>, IClienteWriteEfRepository, IClienteReadEfRepository
    {
        public ClienteEfRepository(DbContext context) : base(context)
        {
        }
    }
}
