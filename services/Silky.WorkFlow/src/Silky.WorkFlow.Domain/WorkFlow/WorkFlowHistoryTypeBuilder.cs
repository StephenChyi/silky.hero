using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Silky.EntityFrameworkCore.Entities.Configures;
using Silky.EntityFrameworkCore.Extras.Modeling;

namespace Silky.WorkFlow.Domain
{
    public class WorkFlowHistoryTypeBuilder : IEntityTypeBuilder<WorkFlowHistory>
    {
        public void Configure(EntityTypeBuilder<WorkFlowHistory> entityBuilder, DbContext dbContext, Type dbContextLocator)
        {
            entityBuilder.ToTable(WorkFlowNodeDbProperties.DbTablePrefix + "WorkFlowHistory", WorkFlowNodeDbProperties.DbSchema);
            entityBuilder.ConfigureByConvention();

            entityBuilder
                .Property(w => w.WorkFlowNodeCode)
                .IsRequired()
                .HasMaxLength(FlowNodeConsts.MaxCodeLength)
                .HasColumnName(nameof(WorkFlowHistory.WorkFlowNodeCode));

            entityBuilder
                 .Property(w => w.NextWorkFlowNodeCode)
                 .IsRequired()
                 .HasMaxLength(FlowNodeConsts.MaxCodeLength)
                 .HasColumnName(nameof(WorkFlowHistory.NextWorkFlowNodeCode));

            entityBuilder
                .Property(w => w.CreatedTime)
                .IsRequired()
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnName(nameof(WorkFlowHistory.CreatedTime));
        }
    }
}
