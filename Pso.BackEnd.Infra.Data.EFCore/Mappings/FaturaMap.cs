using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PSO.BackEnd.Domain.Entities;

namespace Pso.BackEnd.Infra.Data.EFCore.Mappings
{
    public class FaturaMap : IEntityTypeConfiguration<Fatura>
    {
        public void Configure(EntityTypeBuilder<Fatura> builder)
        {
            builder.Ignore(e => e.Valid);
            builder.Ignore(e => e.ValidationResult);
            builder.Ignore(e => e.Invalid);
            builder.HasKey(fat => fat.Id).HasName("PK_Fatura");
            builder.Property(fat => fat.Id).HasColumnName("FaturaId");
            builder.Property(fat => fat.DataPagamento)
                .HasColumnType("date")
                .IsRequired();

            builder.Property(fat => fat.FormaPagamento)
                .HasColumnType("varchar(10)")
                .HasMaxLength(10)
                .IsRequired();

            builder.Property(fat => fat.NumeroParcelas)
                .HasColumnType("integer")
                .IsRequired();

            builder.Property(fat => fat.Sinal)
                .HasColumnType("numeric(10,2)");

            builder.Property(fat => fat.Total).HasColumnName("Total_A_Pagar")
                .HasColumnType("numeric(10,2)")
                .IsRequired();

            builder.Property(fat => fat.Valor)
                .HasColumnType("numeric(10,2)")
                .IsRequired();

            builder.HasMany(f => f.Parcelas)
                .WithOne(p => p.Fatura)
                .HasForeignKey(p => p.FaturaId)
                .HasPrincipalKey(p => p.Id)
                .HasConstraintName("FK_Fatura_Parcela")
                .IsRequired();
        }
    }
}
