using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Silky.EntityFrameworkCore.Entities.Configures;
using Silky.EntityFrameworkCore.Extras.Modeling;
using Silky.Hero.Common.Enums;

namespace Silky.WorkFlow.Domain;

public class WorkFlowNodeTypeBuilder : IEntityTypeBuilder<WorkFlowNode>
{
    public void Configure(EntityTypeBuilder<WorkFlowNode> entityBuilder, DbContext dbContext, Type dbContextLocator)
    {
        entityBuilder.ToTable(WorkFlowDbProperties.DbTablePrefix + "WorkFlowNode", WorkFlowDbProperties.DbSchema);
        entityBuilder.ConfigureByConvention();

        entityBuilder
           .Property(w => w.BusinessCode)
           .IsRequired()
           .HasMaxLength(BusinessCategoryConsts.MaxCodeLength)
           .HasColumnName(nameof(WorkFlowNode.BusinessCode));

        entityBuilder
           .Property(w => w.NodeCode)
           .IsRequired()
           .HasMaxLength(WorkFlowNodeConsts.MaxCodeLength)
           .HasColumnName(nameof(WorkFlowNode.NodeCode));

        entityBuilder
           .Property(w => w.NodeName)
           .IsRequired()
           .HasMaxLength(WorkFlowNodeConsts.MaxNameLength)
           .HasColumnName(nameof(WorkFlowNode.NodeName));

        entityBuilder
           .Property(w => w.NodeVariantId)
           .IsRequired()
           .HasColumnName(nameof(WorkFlowNode.NodeVariantId));

        entityBuilder
           .Property(w => w.NodeAction)
           .IsRequired()
           .HasColumnName(nameof(NodeAction));

        entityBuilder
           .Property(w => w.StepCode)
           .IsRequired()
           .HasColumnName(nameof(WorkFlowNode.StepCode));
    }
}