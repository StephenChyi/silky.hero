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
               .Property(wr => wr.WorkFlowNodeId)
               .IsRequired()
               .HasColumnName(nameof(WorkFlowNodeActionResult.WorkFlowNodeId));

            entityBuilder
               .Property(wr => wr.ProofId)
               .IsRequired()
               .HasColumnName(nameof(WorkFlowNodeActionResult.ProofId));

            entityBuilder
              .Property(f => f.BusinessCategoryCode)
              .IsRequired()
              .HasMaxLength(BusinessCategoryConsts.MaxCodeLength)
              .HasColumnName(nameof(WorkFlowNodeActionResult.BusinessCategoryCode));

            entityBuilder
               .Property(n => n.NodeAction)
               .IsRequired()
               .HasColumnName(nameof(WorkFlowNodeActionResult.NodeAction));
        }
    }
}
