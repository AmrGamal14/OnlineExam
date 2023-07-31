using Data.Audit;
using Infrastructure.ValueGenerators;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration
{
    public abstract class GenericConfiguration<T,TId> : IEntityTypeConfiguration<T> where T : BaseEntity<TId>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<T> builder)
        {
            builder.HasKey(i => i.Id);
            builder.Property(i => i.Id)
                .HasValueGenerator<SeqIdValueGenerator>()
                .ValueGeneratedOnAdd();
            this.CustomConfig(builder);
        }
        public abstract void CustomConfig(EntityTypeBuilder<T> builder);
    }
}
