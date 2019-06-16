using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PSO.BackEnd.Domain.Entities;

namespace Pso.BackEnd.Infra.Data.EFCore.Mappings
{
    public class PedidoMap : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.Ignore(e => e.Valid);
            builder.Ignore(e => e.ValidationResult);
            builder.Ignore(e => e.Invalid);
            builder.HasKey(p => p.PedidoId).HasName("PedidoIdPk");            
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
