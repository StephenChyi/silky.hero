using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Silky.EntityFrameworkCore.Entities.Configures;
using Silky.EntityFrameworkCore.Extras.Modeling;

namespace Silky.WorkFlow.Domain;

public class BusinessCategoryTypeBuilder : IEntityTypeBuilder<BusinessCategory>
{
    public void Configure(EntityTypeBuilder<BusinessCategory> entityBuilder, DbContext dbContext, Type dbContextLocator)
    {
        entityBuilder.ToTable(WorkFlowNodeDbProperties.DbTablePrefix + "BusinessCategory", WorkFlowNodeDbProperties.DbSchema);
        entityBuilder.ConfigureByConvention();

        entityBuilder
            .Property(b => b.BusinessCode)
            .IsRequired()
            .HasMaxLength(BusinessCategoryConsts.MaxCodeLength)
            .HasColumnName(nameof(BusinessCategory.BusinessCode));

        entityBuilder
           .Property(b => b.BusinessName)
           .IsRequired()
           .HasMaxLength(BusinessCategoryConsts.MaxNameLength)
           .HasColumnName(nameof(BusinessCategory.BusinessName));
    }
}