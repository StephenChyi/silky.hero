using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Silky.EntityFrameworkCore.Entities.Configures;
using Silky.EntityFrameworkCore.Extras.Modeling;

namespace Silky.Product.Domain.SKU
{
    public class AttributeValueTypeBuilder : IEntityTypeBuilder<AttributeValue>
    {
        public void Configure(EntityTypeBuilder<AttributeValue> builder, DbContext dbContext, Type dbContextLocator)
        {
            builder.ToTable(ProductDbProperties.DbTablePrefix + "AttributeValue", ProductDbProperties.DbSchema);
            builder.ConfigureByConvention();

            builder.Property(c => c.Priority).IsRequired().HasColumnName(nameof(AttributeValue.Priority));
            builder.Property(c => c.AttributeKeyId).IsRequired().HasColumnName(nameof(AttributeValue.AttributeKeyId));
            builder.Property(c => c.Value).IsRequired().HasMaxLength(AttributeConsts.MaxLength).HasColumnName(nameof(AttributeValue.Value));
        }
    }
}
