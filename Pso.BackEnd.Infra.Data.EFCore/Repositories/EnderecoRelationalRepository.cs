using Microsoft.EntityFrameworkCore;
using PSO.BackEnd.Domain.Entities;
using PSO.BackEnd.Domain.Interfaces.Repositories.Relational.Read;
using PSO.BackEnd.Domain.Interfaces.Repositories.Relational.Write;

namespace Pso.BackEnd.Infra.Data.EFCore.Repositories
{
    public class EnderecoRelationalRepository : Repository<Endereco>, IEnderecoWriteRelationalRepository, IEnderecoReadRelationalRepository
    {
        public EnderecoRelationalRepository(DbContext context) : base(context)
        {
        }
    }
}
