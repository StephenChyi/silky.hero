using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Silky.EntityFrameworkCore.Entities.Configures;
using Silky.EntityFrameworkCore.Extras.Modeling;

namespace Silky.WorkFlow.Domain;

public class BusinessCategoryTypeBuilder : IEntityTypeBuilder<BusinessCategory>
{
    public void Configure(EntityTypeBuilder<BusinessCategory> entityBuilder, DbContext dbContext, Type dbContextLocator)
    {
        entityBuilder.ToTable(WorkFlowDbProperties.DbTablePrefix + "BusinessCategory", WorkFlowDbProperties.DbSchema);
        entityBuilder.ConfigureByConvention();

        entityBuilder
            .Property(b => b.BusinessCategoryCode)
            .IsRequired()
            .HasMaxLength(BusinessCategoryConsts.MaxCodeLength)
            .HasColumnName(nameof(BusinessCategory.BusinessCategoryCode));

        entityBuilder
           .Property(b => b.BusinessCategoryName)
           .IsRequired()
           .HasMaxLength(BusinessCategoryConsts.MaxNameLength)
           .HasColumnName(nameof(BusinessCategory.BusinessCategoryName));
    }
}