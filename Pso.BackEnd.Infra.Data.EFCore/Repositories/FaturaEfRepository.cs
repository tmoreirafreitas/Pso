using Microsoft.EntityFrameworkCore;
using PSO.BackEnd.Domain.Entities;
using PSO.BackEnd.Domain.Interfaces.Repositories.Ef.Read;
using PSO.BackEnd.Domain.Interfaces.Repositories.Ef.Write;

namespace Pso.BackEnd.Infra.Data.EFCore.Repositories
{
    public class FaturaEfRepository : Repository<Fatura>, IFaturaWriteEfRepository, IFaturaReadEfRepository
    {
        public FaturaEfRepository(DbContext context) : base(context)
        {
        }
    }
}
