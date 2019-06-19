using Microsoft.EntityFrameworkCore;
using PSO.BackEnd.Domain.Entities;
using PSO.BackEnd.Domain.Interfaces.Repositories.Relational.Read;

namespace Pso.BackEnd.Infra.Data.EFCore.Repositories
{
    public class PedidoOculosRelationalRepository : Repository<PedidoOculos>, IPedidoOculiosWriteRelationalRepository, IPedidoOculosReadRelationalRepository
    {
        public PedidoOculosRelationalRepository(DbContext context) : base(context)
        {

        }
    }
}
