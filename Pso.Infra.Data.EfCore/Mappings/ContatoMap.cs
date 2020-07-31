using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pso.Domain.Entities;

namespace Pso.Infra.Data.EfCore.Mappings
{
    public class ContatoMap : MapBase<Contato>
    {
        public override void OnEntityTypeBuilderConfigure(EntityTypeBuilder<Contato> builder)
        {
            builder.HasKey(c => c.Id).HasName("PK_Contato");
            builder.Property(c => c.Id).HasColumnName("ContatoId");
            builder.Property(c => c.Email)
                .HasColumnType("varchar(40)")
                .HasMaxLength(40)
                .IsRequired();

            builder.Property(c => c.Telefone)
                .HasColumnType("varchar(15)")
                .HasMaxLength(15)
                .IsRequired();

            builder.Property(c => c.Nome)
                .HasColumnType("varchar(80)")
                .HasMaxLength(15)
                .IsRequired();
        }
    }
}
