using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pso.Domain.Entities;

namespace Pso.Infra.Data.EfCore.Mappings
{
    public class ParcelaMap : MapBase<Parcela>
    {
        public override void OnEntityTypeBuilderConfigure(EntityTypeBuilder<Parcela> builder)
        {
            builder.HasKey(p => p.Id).HasName("PK_Parcela");
            builder.Property(p => p.Id).HasColumnName("ParcelaId");
            builder.Property(p => p.DataPagamento)
                .HasColumnType("date")
                .IsRequired();

            builder.Property(p => p.DataVencimento)
                .HasColumnType("date")
                .IsRequired();

            builder.Property(p => p.Numero)
                .HasColumnType("integer")
                .IsRequired();

            builder.Property(p => p.Recebido)
                .HasColumnType("boolean")
                .IsRequired();

            builder.Property(p => p.Valor)
                .HasColumnType("numeric(10,2)")
                .IsRequired();
        }
    }
}
