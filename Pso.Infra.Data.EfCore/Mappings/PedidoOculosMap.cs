using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pso.Domain.Entities;

namespace Pso.Infra.Data.EfCore.Mappings
{
    public class PedidoOculosMap : MapBase<PedidoOculos>
    {
        public override void OnEntityTypeBuilderConfigure(EntityTypeBuilder<PedidoOculos> builder)
        {
            builder.HasKey(po => new { po.PedidoId, po.OculosId }).HasName("PK_Pedido_Oculos");
            builder.HasOne(po => po.Pedido)
                .WithMany(po => po.PedidosOculos)
                .HasForeignKey(po => po.PedidoId).HasConstraintName("FK_Pedido");

            builder.HasOne(po => po.Oculos)
                .WithMany(po => po.PedidosOculos)
                .HasForeignKey(po => po.OculosId).HasConstraintName("FK_Oculos");
        }
    }
}
