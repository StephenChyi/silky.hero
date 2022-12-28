﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Silky.EntityFrameworkCore.Entities.Configures;
using Silky.EntityFrameworkCore.Extras.Modeling;

namespace Silky.WorkFlow.Domain
{
    public class WorkFlowLogTypeBuilder : IEntityTypeBuilder<WorkFlowLog>
    {
        public void Configure(EntityTypeBuilder<WorkFlowLog> entityBuilder, DbContext dbContext, Type dbContextLocator)
        {
            entityBuilder.ToTable(WorkFlowNodeDbProperties.DbTablePrefix + "WorkFlowLog", WorkFlowNodeDbProperties.DbSchema);
            entityBuilder.ConfigureByConvention();

            entityBuilder
                .Property(w => w.WorkFlowNodeCode)
                .IsRequired()
                .HasColumnName(nameof(WorkFlowLog.WorkFlowNodeCode));

            entityBuilder
                .Property(w => w.UserId)
                .IsRequired()
                .HasColumnName(nameof(WorkFlowLog.UserId));

            entityBuilder
                .Property(w => w.UserName)
                .IsRequired()
                .HasMaxLength(WorkFlowLogConsts.MaxNameLength)
                .HasColumnName(nameof(WorkFlowLog.UserName));

            entityBuilder
                .Property(w => w.Memo)
                .IsRequired()
                .HasMaxLength(WorkFlowLogConsts.MaxContentLength)
                .HasColumnName(nameof(WorkFlowLog.Memo));

            entityBuilder
                .Property(w => w.CreatedTime)
                .IsRequired()
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnName(nameof(WorkFlowLog.CreatedTime));
        }
    }
}
