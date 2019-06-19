using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PSO.BackEnd.Domain.Entities;

namespace Pso.BackEnd.Infra.Data.EFCore.Mappings
{
    public class ContatoMap : IEntityTypeConfiguration<Contato>
    {
        public void Configure(EntityTypeBuilder<Contato> builder)
        {
            builder.Ignore(c => c.Valid);
            builder.Ignore(c => c.ValidationResult);
            builder.Ignore(c => c.Invalid);
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
