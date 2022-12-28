using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Silky.EntityFrameworkCore.Entities.Configures;
using Silky.EntityFrameworkCore.Extras.Modeling;

namespace Silky.WorkFlow.Domain;

public class FlowNodeTypeBuilder : IEntityTypeBuilder<FlowNode>
{
    public void Configure(EntityTypeBuilder<FlowNode> entityBuilder, DbContext dbContext, Type dbContextLocator)
    {
        entityBuilder.ToTable(WorkFlowNodeDbProperties.DbTablePrefix + "FlowNode", WorkFlowNodeDbProperties.DbSchema);
        entityBuilder.ConfigureByConvention();

        entityBuilder
           .Property(f => f.BusinessCategoryCode)
           .IsRequired()
           .HasMaxLength(BusinessCategoryConsts.MaxCodeLength)
           .HasColumnName(nameof(FlowNode.BusinessCategoryCode));

        entityBuilder
           .Property(f => f.FlowNodeCode)
           .IsRequired()
           .HasDefaultValue(default(Guid))
           .HasMaxLength(FlowNodeConsts.MaxCodeLength)
           .HasColumnName(nameof(FlowNode.FlowNodeCode));

        entityBuilder
           .Property(f => f.FlowNodeName)
           .IsRequired()
           .HasMaxLength(FlowNodeConsts.MaxNameLength)
           .HasColumnName(nameof(FlowNode.FlowNodeName));

        entityBuilder
           .Property(f => f.NodeType)
           .IsRequired()
           .HasColumnName(nameof(FlowNode.NodeType));

        entityBuilder.HasMany(f => f.NodeCalculations)
            .WithOne(f => f.FlowNode)
            .HasForeignKey(f => f.FlowNodeId);
    }
}