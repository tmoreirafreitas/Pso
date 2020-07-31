using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pso.Domain.Entities;

namespace Pso.Infra.Data.EfCore.Mappings
{
    public class OculosMap : MapBase<Oculos>
    {
        public override void OnEntityTypeBuilderConfigure(EntityTypeBuilder<Oculos> builder)
        {
            builder.HasKey(o => o.Id).HasName("PK_Oculos");
            builder.Property(o => o.Id).HasColumnName("OculosId");
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
                .HasPrincipalKey(o => o.Id)
                .IsRequired();
        }
    }
}
