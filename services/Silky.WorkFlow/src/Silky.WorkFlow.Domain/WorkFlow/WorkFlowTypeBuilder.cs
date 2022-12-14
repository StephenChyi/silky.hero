using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Silky.EntityFrameworkCore.Entities.Configures;
using Silky.EntityFrameworkCore.Extras.Modeling;
using Silky.Hero.Common.Enums;

namespace Silky.WorkFlow.Domain;

public class WorkFlowTypeBuilder : IEntityTypeBuilder<WorkFlow>
{
    public void Configure(EntityTypeBuilder<WorkFlow> entityBuilder, DbContext dbContext, Type dbContextLocator)
    {
        entityBuilder.ToTable(WorkFlowDbProperties.DbTablePrefix + "WorkFlow", WorkFlowDbProperties.DbSchema);
        entityBuilder.ConfigureByConvention();

        entityBuilder
          .Property(b => b.ProofId)
          .IsRequired()
          .HasColumnName(nameof(WorkFlow.ProofId));

        entityBuilder
          .Property(b => b.BusinessCode)
          .IsRequired()
          .HasMaxLength(BusinessCategoryConsts.MaxCodeLength)
          .HasColumnName(nameof(WorkFlow.BusinessCode));

        entityBuilder
          .Property(b => b.NodeCode)
          .IsRequired()
          .HasMaxLength(WorkFlowNodeConsts.MaxCodeLength)
          .HasColumnName(nameof(WorkFlow.NodeCode));

        entityBuilder
          .Property(b => b.NodeName)
          .IsRequired()
          .HasMaxLength(WorkFlowNodeConsts.MaxNameLength)
          .HasColumnName(nameof(WorkFlow.NodeName));

        entityBuilder
          .Property(b => b.NodeType)
          .IsRequired()
          .HasColumnName(nameof(NodeType));

        entityBuilder
          .Property(b => b.NodeVariable)
          .IsRequired()
          .HasMaxLength(NodeVariantConsts.Val)
          .HasColumnName(nameof(WorkFlow.NodeVariable));

        entityBuilder
          .Property(b => b.NodeValue)
          .IsRequired()
          .HasMaxLength(NodeVariantConsts.Val)
          .HasColumnName(nameof(WorkFlow.NodeValue));

        entityBuilder
          .Property(b => b.NodeCode)
          .IsRequired()
          .HasMaxLength(BusinessCategoryConsts.MaxCodeLength)
          .HasColumnName(nameof(WorkFlow.NodeCode));

        entityBuilder
          .Property(b => b.NodeAction)
          .IsRequired()
          .HasColumnName(nameof(NodeAction));

        entityBuilder
         .Property(b => b.ActivityId)
         .IsRequired()
         .HasColumnName(nameof(WorkFlow.ActivityId));
        entityBuilder
         .Property(b => b.PreviousId)
         .IsRequired()
         .HasColumnName(nameof(WorkFlow.PreviousId));
        entityBuilder
         .Property(b => b.NextId)
         .IsRequired()
         .HasColumnName(nameof(WorkFlow.NextId));

    }
}