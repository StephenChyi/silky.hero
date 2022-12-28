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

            builder.Property(c => c.UnitName).IsRequired().HasMaxLength(UnitConsts.MaxNameLength).HasColumnName(nameof(Unit.UnitName));
            builder.Property(c => c.UnitEnName).IsRequired().HasMaxLength(UnitConsts.MaxNameLength).HasColumnName(nameof(Unit.UnitEnName));
        }
    }
}
