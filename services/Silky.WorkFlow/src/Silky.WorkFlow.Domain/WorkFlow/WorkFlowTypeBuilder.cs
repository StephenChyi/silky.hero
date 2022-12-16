using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Silky.EntityFrameworkCore.Entities.Configures;
using Silky.EntityFrameworkCore.Extras.Modeling;
using Silky.Hero.Common.Enums;

namespace Silky.WorkFlow.Domain;

public class WorkFlowTypeBuilder : IEntityTypeBuilder<WorkFlowNode>
{
    public void Configure(EntityTypeBuilder<WorkFlowNode> entityBuilder, DbContext dbContext, Type dbContextLocator)
    {
        entityBuilder.ToTable(WorkFlowNodeDbProperties.DbTablePrefix + "WorkFlow", WorkFlowNodeDbProperties.DbSchema);
        entityBuilder.ConfigureByConvention();

        entityBuilder
          .Property(w => w.ProofId)
          .IsRequired()
          .HasColumnName(nameof(WorkFlowNode.ProofId));

        entityBuilder
          .Property(w => w.BusinessCode)
          .IsRequired()
          .HasMaxLength(BusinessCategoryConsts.MaxCodeLength)
          .HasColumnName(nameof(WorkFlowNode.BusinessCode));

        entityBuilder
          .Property(w => w.FlowNodeCode)
          .IsRequired()
          .HasMaxLength(FlowNodeConsts.MaxCodeLength)
          .HasColumnName(nameof(WorkFlowNode.FlowNodeCode));

        entityBuilder
          .Property(w => w.NodeTypeId)
          .IsRequired()         
          .HasColumnName(nameof(WorkFlowNode.NodeTypeId));
       
        entityBuilder
           .Property(w => w.NodeVariable)
           .IsRequired()
           .HasMaxLength(FlowNodeConsts.MaxNameLength)
           .HasColumnName(nameof(WorkFlowNode.NodeVariable));

        entityBuilder
          .Property(w => w.NodeValue)
          .IsRequired()
          .HasMaxLength(FlowNodeConsts.MaxNameLength)
          .HasColumnName(nameof(WorkFlowNode.NodeValue));

        entityBuilder
          .Property(w => w.NodeAction)
          .IsRequired()
          .HasColumnName(nameof(WorkFlowNode.NodeAction));

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
           .WithOne(w => w.WorkFlow)
           .HasForeignKey(w => w.WorkFlowId);
    }
}