using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Silky.EntityFrameworkCore.Entities.Configures;
using Silky.EntityFrameworkCore.Extras.Modeling;

namespace Silky.WorkFlow.Domain
{
    public class NodeTypeTypeBuilder : IEntityTypeBuilder<NodeType>
    {
        public void Configure(EntityTypeBuilder<NodeType> entityBuilder, DbContext dbContext, Type dbContextLocator)
        {
            entityBuilder.ToTable(WorkFlowNodeDbProperties.DbTablePrefix + "NodeType", WorkFlowNodeDbProperties.DbSchema);
            entityBuilder.ConfigureByConvention();

            entityBuilder
               .Property(n => n.NodeTypeCode)
               .IsRequired()
               .HasMaxLength(NodeTypeConsts.MaxCodeLength)
               .HasColumnName(nameof(NodeType.NodeTypeCode));

            entityBuilder
               .Property(n => n.NodeTypeName)
               .IsRequired()
               .HasMaxLength(NodeTypeConsts.MaxNameLength)
               .HasColumnName(nameof(NodeType.NodeTypeName));

            entityBuilder.HasMany(n => n.FlowNodes)
                .WithOne(f => f.NodeType)
                .HasForeignKey(f => f.NodeTypeId);

            entityBuilder.HasMany(n => n.WorkFlows)
                .WithOne(w => w.NodeType)
                .HasForeignKey(w => w.NodeTypeId);
        }
    }
}
