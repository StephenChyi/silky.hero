using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Silky.EntityFrameworkCore.Entities.Configures;
using Silky.EntityFrameworkCore.Extras.Modeling;

namespace Silky.WorkFlow.Domain
{
    public class NodeActionResultTypeBuilder : IEntityTypeBuilder<NodeActionResult>
    {
        public void Configure(EntityTypeBuilder<NodeActionResult> entityBuilder, DbContext dbContext, Type dbContextLocator)
        {
            entityBuilder.ToTable(WorkFlowNodeDbProperties.DbTablePrefix + "NodeActionResult", WorkFlowNodeDbProperties.DbSchema);
            entityBuilder.ConfigureByConvention();

            entityBuilder
               .Property(n => n.BusinessCode)
               .IsRequired()
               .HasMaxLength(BusinessCategoryConsts.MaxCodeLength)
               .HasColumnName(nameof(NodeActionResult.BusinessCode));

            entityBuilder
               .Property(n => n.FlowNodeId)
               .IsRequired()
               .HasColumnName(nameof(NodeActionResult.FlowNodeId));

            entityBuilder
               .Property(n => n.FlowNodeCode)
               .IsRequired()
               .HasMaxLength(FlowNodeConsts.MaxCodeLength)
               .HasColumnName(nameof(NodeActionResult.FlowNodeCode));

            entityBuilder
               .Property(n => n.NodeAction)
               .IsRequired()
               .HasColumnName(nameof(WorkFlowNode.NodeAction));

            entityBuilder
               .Property(n => n.NextFlowNodeId)
               .IsRequired()
               .HasColumnName(nameof(NodeActionResult.NextFlowNodeId));

            entityBuilder
               .Property(n => n.NextFlowNodeCode)
               .IsRequired()
               .HasMaxLength(FlowNodeConsts.MaxCodeLength)
               .HasColumnName(nameof(NodeActionResult.NextFlowNodeCode));
        }
    }
}
