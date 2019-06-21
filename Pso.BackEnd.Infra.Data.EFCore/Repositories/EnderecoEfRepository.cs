using Microsoft.EntityFrameworkCore;
using PSO.BackEnd.Domain.Entities;
using PSO.BackEnd.Domain.Interfaces.Repositories.Ef.Read;
using PSO.BackEnd.Domain.Interfaces.Repositories.Ef.Write;

namespace Pso.BackEnd.Infra.Data.EFCore.Repositories
{
    public class EnderecoEfRepository : Repository<Endereco>, IEnderecoWriteEfRepository, IEnderecoReadEfRepository
    {
        public EnderecoEfRepository(DbContext context) : base(context)
        {
        }
    }
}
