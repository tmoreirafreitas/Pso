using Microsoft.EntityFrameworkCore;
using PSO.BackEnd.Domain.Entities;
using PSO.BackEnd.Domain.Interfaces.Repositories.Ef.Read;
using PSO.BackEnd.Domain.Interfaces.Repositories.Ef.Write;

namespace Pso.BackEnd.Infra.Data.EFCore.Repositories
{
    public class ContatoEfRepository : Repository<Contato>, IContatoWriteEfRepository, IContatoReadEfRepository
    {
        public ContatoEfRepository(DbContext context) : base(context)
        {
        }
    }
}
