using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Silky.EntityFrameworkCore.Entities.Configures;
using Silky.EntityFrameworkCore.Extras.Modeling;

namespace Silky.Product.Domain.Depict
{
    public class NatureTypeBuilder : IEntityTypeBuilder<Nature>
    {
        public void Configure(EntityTypeBuilder<Nature> builder, DbContext dbContext, Type dbContextLocator)
        {
            builder.ToTable(ProductDbProperties.DbTablePrefix + "Nature", ProductDbProperties.DbSchema);
            builder.ConfigureByConvention();

            builder.Property(c => c.Name).IsRequired().HasMaxLength(NatureConsts.MaxNameLength).HasColumnName(nameof(Nature.Name));
            builder.Property(c => c.Value).IsRequired().HasMaxLength(NatureConsts.MaxValueLength).HasColumnName(nameof(Nature.Value));
        }
    }
}
