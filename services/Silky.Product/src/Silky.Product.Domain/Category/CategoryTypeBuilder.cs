using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Silky.EntityFrameworkCore.Entities.Configures;
using Silky.EntityFrameworkCore.Extras.Modeling;

namespace Silky.Product.Domain.Category
{
    public class CategoryTypeBuilder : IEntityTypeBuilder<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder, DbContext dbContext, Type dbContextLocator)
        {
            builder.ToTable(ProductDbProperties.DbTablePrefix + "ProductCategory", ProductDbProperties.DbSchema);
            builder.ConfigureByConvention();

            builder.Property(c => c.ParentId).HasColumnName(nameof(Category.ParentId));
            builder.Property(c => c.Code).IsRequired().HasMaxLength(CategoryConsts.MaxCodeLength).HasColumnName(nameof(Category.Code));
            builder.Property(c => c.Name).IsRequired().HasMaxLength(CategoryConsts.MaxNameLength).HasColumnName(nameof(Category.Name));
            builder.Property(c => c.Sort).HasColumnName(nameof(Category.Sort));
            builder.Property(c => c.LevelCode).IsRequired().HasMaxLength(CategoryConsts.MaxCodeLength).HasColumnName(nameof(Category.LevelCode));
            builder.HasMany(o => o.Children).WithOne(o => o.Parent).HasForeignKey(o => o.ParentId);
        }
    }
}
