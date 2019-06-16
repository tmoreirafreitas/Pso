using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PSO.BackEnd.Domain.Entities;

namespace Pso.BackEnd.Infra.Data.EFCore.Mappings
{
    public class PedidoOculosMap : IEntityTypeConfiguration<PedidoOculos>
    {
        public void Configure(EntityTypeBuilder<PedidoOculos> builder)
        {
            builder.Ignore(po => po.Valid);
            builder.Ignore(po => po.ValidationResult);
            builder.Ignore(po => po.Invalid);
            builder.HasKey(po => new { po.PedidoId, po.OculosId });
            builder.HasOne(po => po.Pedido)
                .WithMany(po => po.PedidosOculos)
                .HasForeignKey(po => po.PedidoId).HasConstraintName("FK_Pedido");

            builder.HasOne(po => po.Oculos)
                .WithMany(po => po.PedidosOculos)
                .HasForeignKey(po => po.OculosId).HasConstraintName("FK_Oculos");
        }
    }
}
