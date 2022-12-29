using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Silky.EntityFrameworkCore.Entities.Configures;
using Silky.EntityFrameworkCore.Extras.Modeling;

namespace Silky.Product.Domain.Depict
{
    public class UnitTypeBuilder : IEntityTypeBuilder<Unit>
    {
        public void Configure(EntityTypeBuilder<Unit> builder, DbContext dbContext, Type dbContextLocator)
        {
            builder.ToTable(ProductDbProperties.DbTablePrefix + "Unit", ProductDbProperties.DbSchema);
            builder.ConfigureByConvention();

            builder.Property(c => c.Name).IsRequired().HasMaxLength(UnitConsts.MaxNameLength).HasColumnName(nameof(Unit.Name));
            builder.Property(c => c.EnName).IsRequired().HasMaxLength(UnitConsts.MaxNameLength).HasColumnName(nameof(Unit.EnName));
        }
    }
}
