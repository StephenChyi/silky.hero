using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Silky.EntityFrameworkCore.Entities.Configures;
using Silky.EntityFrameworkCore.Extras.Modeling;

namespace Silky.WorkFlow.Domain
{
    public class NodeCalculationTypeBuilder : IEntityTypeBuilder<NodeCalculation>
    {
        public void Configure(EntityTypeBuilder<NodeCalculation> entityBuilder, DbContext dbContext, Type dbContextLocator)
        {
            entityBuilder.ToTable(WorkFlowNodeDbProperties.DbTablePrefix + "NodeCalculation", WorkFlowNodeDbProperties.DbSchema);
            entityBuilder.ConfigureByConvention();

            entityBuilder
              .Property(f => f.NodeVariable)
              .IsRequired()
              .HasMaxLength(NodeCalculationConsts.MaxNameLength)
              .HasColumnName(nameof(NodeCalculation.NodeVariable));
            entityBuilder
              .Property(f => f.NodeFactor)
              .IsRequired()
              .HasColumnName(nameof(NodeCalculation.NodeFactor));
            entityBuilder
              .Property(f => f.NodeValue)
              .IsRequired()
              .HasMaxLength(NodeCalculationConsts.MaxCodeLength)
              .HasColumnName(nameof(NodeCalculation.NodeValue));
            entityBuilder
              .Property(f => f.NodeInseries)
              .HasMaxLength(NodeCalculationConsts.MaxCodeLength)
              .HasColumnName(nameof(NodeCalculation.NodeInseries));
            entityBuilder
              .Property(f => f.NodeStepNo)
              .IsRequired()
              .HasColumnName(nameof(NodeCalculation.NodeStepNo));
        }
    }
}
