using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Silky.EntityFrameworkCore.Entities.Configures;
using Silky.EntityFrameworkCore.Extras.Modeling;

namespace Silky.Product.Domain.Depict
{
    public class SpecificationTypeBuilder : IEntityTypeBuilder<Specification>
    {
        public void Configure(EntityTypeBuilder<Specification> builder, DbContext dbContext, Type dbContextLocator)
        {
            builder.ToTable(ProductDbProperties.DbTablePrefix + "Specification", ProductDbProperties.DbSchema);
            builder.ConfigureByConvention();

            builder.Property(c => c.Name).IsRequired().HasMaxLength(SpecificationConsts.MaxNameLength).HasColumnName(nameof(Specification.Name));
            builder.Property(c => c.Value).IsRequired().HasMaxLength(SpecificationConsts.MaxValueLength).HasColumnName(nameof(Specification.Value));
            builder.Property(c => c.Take).IsRequired().HasMaxLength(SpecificationConsts.MaxExtendLength).HasColumnName(nameof(Specification.Take));
            builder.Property(c => c.Extend).IsRequired().HasMaxLength(SpecificationConsts.MaxExtendLength).HasColumnName(nameof(Specification.Extend));
        }
    }
}
