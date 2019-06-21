using Microsoft.EntityFrameworkCore;
using PSO.BackEnd.Domain.Entities;
using PSO.BackEnd.Domain.Interfaces.Repositories.Ef.Read;
using PSO.BackEnd.Domain.Interfaces.Repositories.Ef.Write;

namespace Pso.BackEnd.Infra.Data.EFCore.Repositories
{
    public class PedidoOculosEfRepository : Repository<PedidoOculos>, IPedidoOculosWriteEfRepository, IPedidoOculosReadEfRepository
    {
        public PedidoOculosEfRepository(DbContext context) : base(context)
        {

        }
    }
}
