using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Silky.EntityFrameworkCore.Entities.Configures;
using Silky.EntityFrameworkCore.Extras.Modeling;

namespace Silky.Product.Domain.SKU
{
    public class AttributeKeyTypeBuilder : IEntityTypeBuilder<AttributeKey>
    {
        public void Configure(EntityTypeBuilder<AttributeKey> builder, DbContext dbContext, Type dbContextLocator)
        {
            builder.ToTable(ProductDbProperties.DbTablePrefix + "AttributeKey", ProductDbProperties.DbSchema);
            builder.ConfigureByConvention();

            builder.Property(c => c.Priority).IsRequired().HasColumnName(nameof(AttributeKey.Priority));
            builder.Property(c => c.Name).IsRequired().HasMaxLength(AttributeConsts.MaxLength).HasColumnName(nameof(AttributeKey.Name));
            builder.Property(c => c.CategoryId).IsRequired().HasColumnName(nameof(AttributeKey.CategoryId));
            builder.Property(c => c.Status).IsRequired().HasColumnName(nameof(AttributeKey.Status));

            builder.HasMany(k => k.AttributeValues).WithOne(v => v.AttributeKey).HasForeignKey(v => v.AttributeKeyId);
        }
    }
}
