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
           .Property(f => f.BusinessCode)
           .IsRequired()
           .HasMaxLength(BusinessCategoryConsts.MaxCodeLength)
           .HasColumnName(nameof(FlowNode.BusinessCode));

        entityBuilder
           .Property(f => f.FlowNodeCode)
           .IsRequired()
           .HasMaxLength(FlowNodeConsts.MaxCodeLength)
           .HasColumnName(nameof(FlowNode.FlowNodeCode));

        entityBuilder
           .Property(f => f.FlowNodeName)
           .IsRequired()
           .HasMaxLength(FlowNodeConsts.MaxNameLength)
           .HasColumnName(nameof(FlowNode.FlowNodeName));

        entityBuilder
           .Property(f => f.NodeTypeId)
           .IsRequired()
           .HasColumnName(nameof(FlowNode.NodeTypeId));

        entityBuilder
           .Property(f => f.NodeVariable)
           .IsRequired()
           .HasMaxLength(FlowNodeConsts.MaxNameLength)
           .HasColumnName(nameof(FlowNode.NodeVariable));

        entityBuilder
          .Property(f => f.NodeValue)
          .IsRequired()
          .HasMaxLength(FlowNodeConsts.MaxNameLength)
          .HasColumnName(nameof(FlowNode.NodeValue));

        entityBuilder.HasMany(f => f.NextFlowNodes)
           .WithOne(f => f.FlowNode)
           .HasForeignKey(n => n.FlowNodeId);
    }
}