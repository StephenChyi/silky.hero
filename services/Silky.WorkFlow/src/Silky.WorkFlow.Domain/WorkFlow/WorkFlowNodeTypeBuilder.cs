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
          .Property(w => w.ProofId)
          .IsRequired()
          .HasColumnName(nameof(WorkFlowNode.ProofId));

        entityBuilder
          .Property(w => w.BusinessCategoryCode)
          .IsRequired()
          .HasMaxLength(BusinessCategoryConsts.MaxCodeLength)
          .HasColumnName(nameof(WorkFlowNode.BusinessCategoryCode));

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
          .Property(w => w.NodeTypeId)
          .IsRequired()
          .HasColumnName(nameof(WorkFlowNode.NodeTypeId));

        entityBuilder
          .Property(w => w.StepNo)
          .IsRequired()
          .HasColumnName(nameof(WorkFlowNode.StepNo));

        entityBuilder
          .Property(w => w.NodeStatus)
          .IsRequired()
          .HasDefaultValue(WorkFlowNodeStatus.Incoming)
          .HasColumnName(nameof(WorkFlowNode.NodeStatus));

        entityBuilder
          .Property(w => w.PreviousId)
          .IsRequired()
          .HasColumnName(nameof(WorkFlowNode.PreviousId));

        entityBuilder.HasMany(w => w.NextFlowNodes)
           .WithOne(w => w.WorkFlowNode)
           .HasForeignKey(w => w.WorkFlowNodeId);

        entityBuilder.HasMany(w => w.NodeCalculations)
           .WithOne(w => w.WorkFlowNode)
           .HasForeignKey(w => w.WorkFlowNodeId);
    }
}