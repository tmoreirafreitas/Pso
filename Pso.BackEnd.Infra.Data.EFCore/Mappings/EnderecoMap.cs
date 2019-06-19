using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PSO.BackEnd.Domain.Entities;

namespace Pso.BackEnd.Infra.Data.EFCore.Mappings
{
    public class EnderecoMap : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.Ignore(e => e.Valid);
            builder.Ignore(e => e.ValidationResult);
            builder.Ignore(e => e.Invalid);
            builder.HasKey(e=>e.Id).HasName("PK_Endereco");
            builder.Property(e => e.Id).HasColumnName("EnderecoId");

            builder.Property(e => e.Bairro)
                .HasColumnType("varchar(60)")
                .HasMaxLength(40)
                .IsRequired();

            builder.Property(e => e.Cep)
                .HasColumnType("varchar(9)")
                .HasMaxLength(9)
                .IsRequired();

            builder.Property(e => e.Cidade)
                .HasColumnType("varchar(40)")
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(e => e.Complemento)
                .HasColumnType("varchar(150)")
                .HasMaxLength(100);

            builder.Property(e => e.Estado)
                .HasColumnType("varchar(30)")
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(e => e.Logradouro)
                .HasColumnType("varchar(40)")
                .HasMaxLength(40)
                .IsRequired();

            builder.Property(e => e.Numero)
                .HasColumnType("integer");
        }
    }
}
