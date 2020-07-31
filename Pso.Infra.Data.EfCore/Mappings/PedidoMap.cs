using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pso.Domain.Entities;

namespace Pso.Infra.Data.EfCore.Mappings
{
    public class PedidoMap : MapBase<Pedido>
    {
        public override void OnEntityTypeBuilderConfigure(EntityTypeBuilder<Pedido> builder)
        {
            builder.HasKey(p => p.Id).HasName("PedidoIdPk");
            builder.Property(p => p.Id).HasColumnName("PedidoId");
            builder.Property(p => p.DataSolicitacao)
                .HasColumnType("date")
                .IsRequired();

            builder.Property(p => p.DataEntrega)
                .HasColumnType("date")
                .IsRequired();

            builder.Property(p => p.Medico)
                .HasColumnType("varchar(80)")
                .IsRequired();

            builder.Property(p => p.Obs)
                .HasColumnType("varchar(255)")
                .IsRequired();

            builder.Property(p => p.Preco)
                .HasColumnType("numeric(10,2)")
                .IsRequired();

            builder.Property(p => p.Servico)
                .HasColumnType("varchar(1000)")
                .IsRequired();

            builder.HasOne(p => p.Fatura)
                .WithOne(f => f.Pedido)
                .HasForeignKey<Fatura>(f => f.PedidoId)
                .IsRequired();
        }
    }
}
