using Microsoft.EntityFrameworkCore;
using Pso.Domain.Entities;
using Pso.Domain.Interfaces.Repositories.Ef.Read;
using Pso.Domain.Interfaces.Repositories.Ef.Write;

namespace Pso.Infra.Data.EfCore.Repositories
{
    public class PedidoEfRepository : Repository<Pedido>, IPedidoWriteEfRepository, IPedidoReadEfRepository
    {
        public PedidoEfRepository(DbContext context) : base(context)
        {
        }
    }
}
