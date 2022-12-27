using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Silky.EntityFrameworkCore.Entities.Configures;
using Silky.EntityFrameworkCore.Extras.Modeling;

namespace Silky.WorkFlow.Domain
{
    public class FlowLineTypeBuilder : IEntityTypeBuilder<FlowLine>
    {
        public void Configure(EntityTypeBuilder<FlowLine> entityBuilder, DbContext dbContext, Type dbContextLocator)
        {
            entityBuilder.ToTable(WorkFlowNodeDbProperties.DbTablePrefix + "FlowLine", WorkFlowNodeDbProperties.DbSchema);
            entityBuilder.ConfigureByConvention();

            entityBuilder
               .Property(f => f.BusinessCategoryCode)
               .IsRequired()
               .HasMaxLength(BusinessCategoryConsts.MaxCodeLength)
               .HasColumnName(nameof(FlowLine.BusinessCategoryCode));

            entityBuilder
              .Property(f => f.FlowLineName)
              .IsRequired()
              .HasMaxLength(FlowLineConsts.MaxCodeLength)
              .HasColumnName(nameof(FlowLine.FlowLineName));

            entityBuilder
               .Property(n => n.PrevFlowNodeId)
               .IsRequired()
               .HasColumnName(nameof(FlowLine.PrevFlowNodeId));

            entityBuilder
               .Property(n => n.FlowNodeId)
               .IsRequired()
               .HasDefaultValue(1)
               .HasColumnName(nameof(FlowLine.FlowNodeId));
        }
    }
}
