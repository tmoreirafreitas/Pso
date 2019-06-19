using Microsoft.EntityFrameworkCore;
using PSO.BackEnd.Domain.Entities;
using PSO.BackEnd.Domain.Interfaces.Repositories.Relational.Read;
using PSO.BackEnd.Domain.Interfaces.Repositories.Relational.Write;

namespace Pso.BackEnd.Infra.Data.EFCore.Repositories
{
    public class LenteRelationalRepository : Repository<Lente>, ILenteWriteRelationalRepository, ILenteReadRelationalRepository
    {
        public LenteRelationalRepository(DbContext context) : base(context)
        {
        }
    }
}
