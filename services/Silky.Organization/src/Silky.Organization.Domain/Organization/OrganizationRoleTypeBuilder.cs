﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Silky.EntityFrameworkCore.Entities.Configures;
using Silky.EntityFrameworkCore.Extras.Modeling;
using System;

namespace Silky.Organization.Domain;

public class OrganizationRoleTypeBuilder : IEntityTypeBuilder<OrganizationRole>
{
    public void Configure(EntityTypeBuilder<OrganizationRole> builder, DbContext dbContext, Type dbContextLocator)
    {
        builder.ToTable(OrganizationDbProperties.DbTablePrefix + "OrganizationRoles", OrganizationDbProperties.DbSchema);
        builder.ConfigureByConvention();

        builder.Property(o => o.OrganizationId)
            .IsRequired()
            .HasColumnName(nameof(Domain.OrganizationRole.OrganizationId));

        builder.Property(o => o.RoleId)
            .IsRequired()
            .HasColumnName(nameof(Domain.OrganizationRole.RoleId));
    }
}