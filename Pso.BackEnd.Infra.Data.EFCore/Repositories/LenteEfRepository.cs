using Microsoft.EntityFrameworkCore;
using PSO.BackEnd.Domain.Entities;
using PSO.BackEnd.Domain.Interfaces.Repositories.Ef.Read;
using PSO.BackEnd.Domain.Interfaces.Repositories.Ef.Write;

namespace Pso.BackEnd.Infra.Data.EFCore.Repositories
{
    public class LenteEfRepository : Repository<Lente>, ILenteWriteEfRepository, ILenteReadEfRepository
    {
        public LenteEfRepository(DbContext context) : base(context)
        {
        }
    }
}
