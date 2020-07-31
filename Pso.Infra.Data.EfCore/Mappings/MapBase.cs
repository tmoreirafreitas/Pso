using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pso.Domain.Entities;

namespace Pso.Infra.Data.EfCore.Mappings
{
    public abstract class MapBase<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : Entity    
    {
        public void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.Ignore(e => e.Valid);
            builder.Ignore(e => e.ValidationResult);
            builder.Ignore(e => e.Invalid);
            builder.Ignore(x => x.ObjectId);
            OnEntityTypeBuilderConfigure(builder);
        }

        public abstract void OnEntityTypeBuilderConfigure(EntityTypeBuilder<TEntity> builder);
    }
}