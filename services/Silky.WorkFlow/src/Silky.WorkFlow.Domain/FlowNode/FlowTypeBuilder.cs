using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Silky.EntityFrameworkCore.Entities.Configures;
using Silky.EntityFrameworkCore.Extras.Modeling;

namespace Silky.WorkFlow.Domain
{
    /// <summary>
    /// 一个业务流
    /// </summary>
    public class FlowTypeBuilder : IEntityTypeBuilder<Flow>
    {
        public void Configure(EntityTypeBuilder<Flow> entityBuilder, DbContext dbContext, Type dbContextLocator)
        {
            entityBuilder.ToTable(WorkFlowNodeDbProperties.DbTablePrefix + "Flow", WorkFlowNodeDbProperties.DbSchema);
            entityBuilder.ConfigureByConvention();

            entityBuilder
                .Property(f => f.BusinessCategoryCode)
                .IsRequired()
                .HasMaxLength(BusinessCategoryConsts.MaxCodeLength)
                .HasColumnName(nameof(Flow.BusinessCategoryCode));

            entityBuilder
                .Property(f => f.FlowName)
                .IsRequired()
                .HasMaxLength(FlowConsts.MaxCodeLength)
                .HasColumnName(nameof(Flow.FlowName));

            entityBuilder.HasMany(f => f.FlowNodes)
                .WithOne(f => f.Flow)
                .HasForeignKey(f => f.FlowId);

            entityBuilder.HasMany(f => f.FlowLines)
                .WithOne(f => f.Flow)
                .HasForeignKey(f => f.FlowId);
        }
    }
}
