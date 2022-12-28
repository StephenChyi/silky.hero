using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Silky.EntityFrameworkCore.Entities.Configures;
using Silky.EntityFrameworkCore.Extras.Modeling;

namespace Silky.WorkFlow.Domain;

public class WorkFlowLineTypeBuilder : IEntityTypeBuilder<WorkFlowLine>
{
    public void Configure(EntityTypeBuilder<WorkFlowLine> entityBuilder, DbContext dbContext, Type dbContextLocator)
    {
        entityBuilder.ToTable(WorkFlowNodeDbProperties.DbTablePrefix + "WorkFlowLine", WorkFlowNodeDbProperties.DbSchema);
        entityBuilder.ConfigureByConvention();

        entityBuilder
          .Property(w => w.WorkFlowLineName)
          .IsRequired()
          .HasColumnName(nameof(WorkFlowLine.WorkFlowLineName));

        entityBuilder
          .Property(w => w.PrevWorkFlowNodeCode)
          .IsRequired()
          .HasMaxLength(FlowLineConsts.MaxCodeLength)
          .HasColumnName(nameof(WorkFlowLine.PrevWorkFlowNodeCode));

        entityBuilder
          .Property(w => w.ActionType)
          .IsRequired()
          .HasColumnName(nameof(WorkFlowLine.ActionType));

        entityBuilder
          .Property(w => w.WorkFlowNodeCode)
          .IsRequired()
          .HasMaxLength(FlowLineConsts.MaxCodeLength)
          .HasColumnName(nameof(WorkFlowLine.WorkFlowNodeCode));
    }
}