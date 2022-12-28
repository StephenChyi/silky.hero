using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Silky.EntityFrameworkCore.Entities.Configures;
using Silky.EntityFrameworkCore.Extras.Modeling;

namespace Silky.WorkFlow.Domain;

public class WorkFlowTypeBuilder : IEntityTypeBuilder<WorkFlow>
{
    public void Configure(EntityTypeBuilder<WorkFlow> entityBuilder, DbContext dbContext, Type dbContextLocator)
    {
        entityBuilder.ToTable(WorkFlowDbProperties.DbTablePrefix + "WorkFlow", WorkFlowDbProperties.DbSchema);
        entityBuilder.ConfigureByConvention();

        entityBuilder
          .Property(w => w.ProofId)
          .IsRequired()
          .HasColumnName(nameof(WorkFlow.ProofId));

        entityBuilder
          .Property(w => w.BusinessCategoryCode)
          .IsRequired()
          .HasMaxLength(BusinessCategoryConsts.MaxCodeLength)
          .HasColumnName(nameof(WorkFlow.BusinessCategoryCode));

        entityBuilder
          .Property(w => w.WorkFlowName)
          .IsRequired()
          .HasMaxLength(WorkFlowConsts.MaxNameLength)
          .HasColumnName(nameof(WorkFlow.WorkFlowName));

        entityBuilder
          .Property(w => w.PreviousNodeCode)          
          .HasMaxLength(FlowNodeConsts.MaxCodeLength)
          .HasColumnName(nameof(WorkFlow.PreviousNodeCode));

        entityBuilder
          .Property(w => w.CurrentNodeCode)
          .IsRequired()
          .HasMaxLength(FlowNodeConsts.MaxCodeLength)
          .HasColumnName(nameof(WorkFlow.CurrentNodeCode));

        entityBuilder
          .Property(w => w.CurrentUserId)
          .IsRequired()
          .HasColumnName(nameof(WorkFlow.CurrentUserId));

        entityBuilder
          .Property(w => w.CurrentUserName)
          .IsRequired()
          .HasMaxLength(WorkFlowConsts.MaxNameLength)
          .HasColumnName(nameof(WorkFlow.CurrentUserName));

        entityBuilder.HasMany(w => w.WorkFlowNodes)
           .WithOne(w => w.WorkFlow)
           .HasForeignKey(w => w.WorkFlowId);

        entityBuilder.HasMany(w => w.WorkFlowLines)
           .WithOne(w => w.WorkFlow)
           .HasForeignKey(w => w.WorkFlowId);

        entityBuilder.HasMany(w => w.WorkFlowLogs)
           .WithOne(w => w.WorkFlow)
           .HasForeignKey(w => w.WorkFlowId);

        entityBuilder.HasMany(w => w.WorkFlowHistories)
           .WithOne(w => w.WorkFlow)
           .HasForeignKey(w => w.WorkFlowId);
    }
}