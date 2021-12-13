﻿using System;
using JetBrains.Annotations;
using Silky.Hero.Common.EntityFrameworkCore.Entities;
using Silky.Hero.Common.Enums;

namespace Silky.Position.Domain;

public class Position : FullAuditedEntity, IHasConcurrencyStamp
{
    public Position()
    {
        ConcurrencyStamp = Guid.NewGuid().ToString();
    }

    [NotNull] public string Name { get; set; }

    [NotNull] public string Code { get; set; }

    public int Sort { get; set; }

    public string Remark { get; set; }

    public Status Status { get; set; }
    public string ConcurrencyStamp { get; set; }
    
}