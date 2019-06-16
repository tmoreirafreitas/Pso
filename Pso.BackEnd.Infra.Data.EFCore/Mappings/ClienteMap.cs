using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PSO.BackEnd.Domain.Entities;

namespace Pso.BackEnd.Infra.Data.EFCore.Mappings
{
    public class ClienteMap : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.Ignore(e => e.Valid);
            builder.Ignore(e => e.ValidationResult);
            builder.Ignore(e => e.Invalid);
            builder.HasKey(c => c.ClienteId).HasName("PK_Cliente");
            builder.Property(c => c.Cpf)
                .HasColumnType("varchar(11)")
                .HasMaxLength(15)
                .IsRequired();

            builder.Property(c => c.Email)
                .HasColumnType("varchar(60)")
                .HasMaxLength(40)
                .IsRequired();

            builder.Property(c => c.Filiacao)
                .HasColumnType("varchar(200)")
                .HasMaxLength(150);

            builder.Property(c => c.IsSPC);

            builder.Property(c => c.Nascimento)
                .HasColumnType("date");

            builder.Property(c => c.Nome)
                .HasColumnType("varchar(80)")
                .HasMaxLength(60)
                .IsRequired();

            builder.Property(c => c.Rg)
                .HasColumnType("varchar(10)")
                .HasMaxLength(10);

            //var converter = new EnumToStringConverter<SexoType>();
            builder.Property(c => c.Sexo)
                .HasColumnType("varchar(10)")
                .HasMaxLength(10);

            builder.HasOne(c => c.Endereco)
                .WithOne(e => e.Cliente)
                .HasForeignKey<Endereco>(e => e.ClienteId)
                .IsRequired();

            builder.HasMany(c => c.Pedidos)
                .WithOne(p => p.Cliente)
                .HasForeignKey(p => p.ClienteId)
                .HasPrincipalKey(p => p.ClienteId)
                .HasConstraintName("FK_Cliente_Pedido")
                .IsRequired();

            builder.HasMany(c => c.Contatos)
                .WithOne(p => p.Cliente)
                .HasForeignKey(p => p.ClienteId)
                .HasPrincipalKey(p => p.ClienteId)
                .HasConstraintName("FK_Cliente_Contato")
                .IsRequired();
        }
    }
}