using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Silky.EntityFrameworkCore.Entities.Configures;
using Silky.EntityFrameworkCore.Extras.Modeling;
using Silky.WorkFlow.Domain.Shared;

namespace Silky.WorkFlow.Domain;

public class WorkFlowNodeTypeBuilder : IEntityTypeBuilder<WorkFlowNode>
{
    public void Configure(EntityTypeBuilder<WorkFlowNode> entityBuilder, DbContext dbContext, Type dbContextLocator)
    {
        entityBuilder.ToTable(WorkFlowNodeDbProperties.DbTablePrefix + "WorkFlowNode", WorkFlowNodeDbProperties.DbSchema);
        entityBuilder.ConfigureByConvention();

        entityBuilder
          .Property(w => w.FlowNodeCode)
          .IsRequired()
          .HasMaxLength(FlowNodeConsts.MaxCodeLength)
          .HasColumnName(nameof(WorkFlowNode.FlowNodeCode));

        entityBuilder
          .Property(w => w.FlowNodeName)
          .IsRequired()
          .HasMaxLength(FlowNodeConsts.MaxNameLength)
          .HasColumnName(nameof(WorkFlowNode.FlowNodeName));

        entityBuilder
          .Property(w => w.NodeType)
          .IsRequired()
          .HasColumnName(nameof(WorkFlowNode.NodeType));

        entityBuilder
          .Property(w => w.NodeVariable)
          .IsRequired()
          .HasMaxLength(WorkFlowNodeConsts.MaxNameLength)
          .HasColumnName(nameof(WorkFlowNode.NodeVariable));

        entityBuilder
          .Property(w => w.NodeValue)
          .IsRequired()
          .HasMaxLength(WorkFlowNodeConsts.MaxCodeLength)
          .HasColumnName(nameof(WorkFlowNode.NodeValue));

        entityBuilder
          .Property(w => w.StepNo)
          .IsRequired()
          .HasColumnName(nameof(WorkFlowNode.StepNo));
        entityBuilder
          .Property(w => w.NodeStatus)
          .IsRequired()
          .HasDefaultValue(WorkFlowNodeStatus.Incoming)
          .HasColumnName(nameof(WorkFlowNode.NodeStatus));
    }
}