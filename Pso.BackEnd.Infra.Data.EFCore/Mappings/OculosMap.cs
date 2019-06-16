using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PSO.BackEnd.Domain.Entities;

namespace Pso.BackEnd.Infra.Data.EFCore.Mappings
{
    public class OculosMap : IEntityTypeConfiguration<Oculos>
    {
        public void Configure(EntityTypeBuilder<Oculos> builder)
        {
            builder.Ignore(e => e.Valid);
            builder.Ignore(e => e.ValidationResult);
            builder.Ignore(e => e.Invalid);
            builder.HasKey(o => o.OculosId).HasName("PK_Oculos");
            builder.Property(o => o.OculosId);
            builder.Property(o => o.Adicao)
                .HasColumnType("float");

            builder.Property(o => o.ALT)
                .HasColumnType("float");

            builder.Property(o => o.Cor)
                .HasColumnType("varchar(30)");

            builder.Property(o => o.DP)
                .HasColumnType("float");

            builder.HasMany(o => o.Lentes)
                .WithOne(l => l.Oculos)
                .HasForeignKey(l => l.OculosId)
                .HasPrincipalKey(o => o.OculosId)
                .IsRequired();
        }
    }
}
