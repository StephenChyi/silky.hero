using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Silky.EntityFrameworkCore.Entities.Configures;
using Silky.EntityFrameworkCore.Extras.Modeling;

namespace Silky.WorkFlow.Domain
{
    public class WorkFlowNodeActionResultTypeBuilder : IEntityTypeBuilder<WorkFlowNodeActionResult>
    {
        public void Configure(EntityTypeBuilder<WorkFlowNodeActionResult> entityBuilder, DbContext dbContext, Type dbContextLocator)
        {
            entityBuilder.ToTable(WorkFlowNodeDbProperties.DbTablePrefix + "WorkFlowNodeActionResult", WorkFlowNodeDbProperties.DbSchema);
            entityBuilder.ConfigureByConvention();

            entityBuilder
               .Property(wr => wr.WorkFlowId)
               .IsRequired()
               .HasColumnName(nameof(WorkFlowNodeActionResult.WorkFlowId));

            entityBuilder
               .Property(wr => wr.FlowNodeCode)
               .IsRequired()
               .HasMaxLength(FlowNodeConsts.MaxCodeLength)
               .HasColumnName(nameof(WorkFlowNodeActionResult.FlowNodeCode));

            entityBuilder
               .Property(n => n.NodeAction)
               .IsRequired()
               .HasColumnName(nameof(WorkFlowNodeActionResult.NodeAction));

            entityBuilder
               .Property(n => n.NextFlowNodeId)
               .IsRequired()
               .HasColumnName(nameof(WorkFlowNodeActionResult.NextFlowNodeId));

            entityBuilder
               .Property(n => n.NextFlowNodeCode)
               .IsRequired()
               .HasMaxLength(FlowNodeConsts.MaxCodeLength)
               .HasColumnName(nameof(WorkFlowNodeActionResult.NextFlowNodeCode));
        }
    }
}
