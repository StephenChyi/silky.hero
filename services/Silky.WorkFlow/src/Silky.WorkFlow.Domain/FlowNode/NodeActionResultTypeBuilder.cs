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
               .Property(n => n.PrevFlowNodeId)
               .IsRequired()
               .HasColumnName(nameof(NodeActionResult.PrevFlowNodeId));

            entityBuilder
               .Property(f => f.BusinessCategoryCode)
               .IsRequired()
               .HasMaxLength(BusinessCategoryConsts.MaxCodeLength)
               .HasColumnName(nameof(NodeActionResult.BusinessCategoryCode));

            entityBuilder
               .Property(n => n.FlowNodeId)
               .IsRequired()
               .HasDefaultValue(1)
               .HasColumnName(nameof(NodeActionResult.FlowNodeId));

            entityBuilder
               .Property(n => n.NodeAction)
               .IsRequired()
               .HasColumnName(nameof(NodeActionResult.NodeAction));
        }
    }
}
