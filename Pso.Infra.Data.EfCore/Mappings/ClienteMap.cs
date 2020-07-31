using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pso.Domain.Entities;

namespace Pso.Infra.Data.EfCore.Mappings
{
    public class ClienteMap : MapBase<Cliente>
    {
        public override void OnEntityTypeBuilderConfigure(EntityTypeBuilder<Cliente> builder)
        {
            builder.HasKey(c => c.Id).HasName("PK_Cliente");
            builder.Property(c => c.Id).HasColumnName("ClienteId");
            builder.Property(c => c.Cpf)
                .HasColumnType("varchar(11)")
                .HasMaxLength(15)
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
                .HasConstraintName("FK_Cliente_Endereco")
                .IsRequired();

            builder.HasMany(c => c.Pedidos)
                .WithOne(p => p.Cliente)
                .HasForeignKey(p => p.ClienteId)
                .HasPrincipalKey(p => p.Id)
                .HasConstraintName("FK_Cliente_Pedido")
                .IsRequired();

            builder.HasMany(c => c.Contatos)
                .WithOne(c => c.Cliente)
                .HasForeignKey(c => c.ClienteId)
                .HasPrincipalKey(c => c.Id)
                .HasConstraintName("FK_Cliente_Contato")
                .IsRequired();
        }
    }
}