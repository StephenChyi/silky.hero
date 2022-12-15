using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Silky.EntityFrameworkCore.Entities.Configures;
using Silky.EntityFrameworkCore.Extras.Modeling;
using Silky.Hero.Common.Enums;

namespace Silky.WorkFlow.Domain;

public class NodeVariantTypeBuilder : IEntityTypeBuilder<NodeVariant>
{
    public void Configure(EntityTypeBuilder<NodeVariant> entityBuilder, DbContext dbContext, Type dbContextLocator)
    {
        entityBuilder.ToTable(WorkFlowDbProperties.DbTablePrefix + "NodeVariant", WorkFlowDbProperties.DbSchema);
        entityBuilder.ConfigureByConvention();

        entityBuilder
         .Property(b => b.NodeType)
         .IsRequired()
         .HasColumnName(nameof(NodeType));

        entityBuilder
           .Property(n => n.NodeVariable)
           .IsRequired()
           .HasMaxLength(NodeVariantConsts.Val)
           .HasColumnName(nameof(NodeVariant.NodeVariable));

        entityBuilder
           .Property(b => b.NodeValue)
           .IsRequired()
           .HasMaxLength(NodeVariantConsts.Val)
           .HasColumnName(nameof(NodeVariant.NodeValue));
    }
}