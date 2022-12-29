using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Silky.EntityFrameworkCore.Entities.Configures;
using Silky.EntityFrameworkCore.Extras.Modeling;

namespace Silky.Product.Domain.Depict
{
    public class InvoiceArticleTypeBuilder : IEntityTypeBuilder<InvoiceArticle>
    {
        public void Configure(EntityTypeBuilder<InvoiceArticle> builder, DbContext dbContext, Type dbContextLocator)
        {
            builder.ToTable(ProductDbProperties.DbTablePrefix + "InvoiceArticle", ProductDbProperties.DbSchema);
            builder.ConfigureByConvention();

            builder.Property(i => i.Name).IsRequired().HasMaxLength(InvoiceArticleConsts.MaxNameLength).HasColumnName(nameof(InvoiceArticle.Name));
            builder.Property(i => i.Status).IsRequired().HasColumnName(nameof(InvoiceArticle.Status));

            builder.HasMany(i => i.Products).WithOne(p => p.InvoiceArticle).HasForeignKey(p => p.InvoiceArticleId);
        }
    }
}
