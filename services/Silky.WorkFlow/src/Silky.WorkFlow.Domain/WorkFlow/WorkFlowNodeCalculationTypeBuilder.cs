using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Silky.EntityFrameworkCore.Entities.Configures;
using Silky.EntityFrameworkCore.Extras.Modeling;

namespace Silky.WorkFlow.Domain
{
    public class WorkFlowNodeCalculationTypeBuilder : IEntityTypeBuilder<WorkFlowNodeCalculation>
    {
        public void Configure(EntityTypeBuilder<WorkFlowNodeCalculation> entityBuilder, DbContext dbContext, Type dbContextLocator)
        {
            entityBuilder.ToTable(WorkFlowNodeDbProperties.DbTablePrefix + "WorkFlowNodeCalculation", WorkFlowNodeDbProperties.DbSchema);
            entityBuilder.ConfigureByConvention();

            entityBuilder
              .Property(f => f.NodeVariable)
              .IsRequired()
              .HasMaxLength(NodeCalculationConsts.MaxNameLength)
              .HasColumnName(nameof(WorkFlowNodeCalculation.NodeVariable));
            entityBuilder
              .Property(f => f.NodeFactor)
              .IsRequired()
              .HasColumnName(nameof(WorkFlowNodeCalculation.NodeFactor));
            entityBuilder
              .Property(f => f.NodeValue)
              .IsRequired()
              .HasMaxLength(NodeCalculationConsts.MaxCodeLength)
              .HasColumnName(nameof(WorkFlowNodeCalculation.NodeValue));
            entityBuilder
              .Property(f => f.NodeInseries)
              .HasMaxLength(NodeCalculationConsts.MaxCodeLength)
              .HasColumnName(nameof(WorkFlowNodeCalculation.NodeInseries));
            entityBuilder
              .Property(f => f.NodeStepNo)
              .IsRequired()
              .HasColumnName(nameof(WorkFlowNodeCalculation.NodeStepNo));
        }
    }
}
