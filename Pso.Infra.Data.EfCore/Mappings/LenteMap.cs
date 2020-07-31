using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pso.Domain.Entities;

namespace Pso.Infra.Data.EfCore.Mappings
{
    public class LenteMap : MapBase<Lente>
    {
        public override void OnEntityTypeBuilderConfigure(EntityTypeBuilder<Lente> builder)
        {
            builder.HasKey(l => l.Id).HasName("PK_Lente");
            builder.Property(l => l.Id).HasColumnName("LenteId");
            builder.Property(l => l.Cyl)
                .HasColumnType("float");

            builder.Property(l => l.Eixo)
                .HasColumnType("smallint");

            builder.Property(l => l.Grau)
                .HasColumnType("float")
                .IsRequired();

            //var converter = new EnumToStringConverter<LenteType>();
            builder.Property(l => l.LenteType)
                .HasColumnType("varchar(2)")
                .HasMaxLength(2)
                .IsRequired();
        }
    }
}
