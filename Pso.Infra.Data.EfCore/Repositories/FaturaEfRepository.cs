using Microsoft.EntityFrameworkCore;
using Pso.Domain.Entities;
using Pso.Domain.Interfaces.Repositories.Ef.Read;
using Pso.Domain.Interfaces.Repositories.Ef.Write;

namespace Pso.Infra.Data.EfCore.Repositories
{
    public class FaturaEfRepository : Repository<Fatura>, IFaturaWriteEfRepository, IFaturaReadEfRepository
    {
        public FaturaEfRepository(DbContext context) : base(context)
        {
        }
    }
}
