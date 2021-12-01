﻿using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Silky.Hero.Common.Entities;
using Silky.Hero.Common.Enums;

namespace Silky.Organization.Domain.Organizations;

public class Organization : FullAuditedEntity, IHasConcurrencyStamp
{
    public Organization()
    {
        ConcurrencyStamp = Guid.NewGuid().ToString();
        Children = new List<Organization>();
    }

    public long? ParentId { get; set; }

    [NotNull] public string Name { get; set; }

    [NotNull] public string Code { get; set; }

    public int Sort { get; set; }

    public string Remark { get; set; }

    public Status Status { get; set; }

    public string ConcurrencyStamp { get; set; }

    public virtual Organization Parent { get; set; }

    public virtual ICollection<Organization> Children { get; set; }
}