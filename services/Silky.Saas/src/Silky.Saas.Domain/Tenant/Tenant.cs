﻿using Silky.EntityFrameworkCore.Entities;
using Silky.EntityFrameworkCore.Extras.Entities;
using Silky.Hero.Common.EntityFrameworkCore.Entities;
using Silky.Hero.Common.Enums;
using System;

namespace Silky.Saas.Domain;

public class Tenant : Entity<long>, ICreatedObject, IUpdatedObject, ISoftDeletedObject
{
    public Tenant()
    {
    }

    public Tenant(long id, int editionId, string name, string realName, Status status, string remark)
    {
        Id = id;
        Name = name;
        RealName = name;
        Status = status;
        Remark = remark;
        EditionId = editionId;
    }

    public string Name { get; set; }

    public string RealName { get; set; }

    public Status Status { get; set; }

    public int Sort { get; set; }

    public long EditionId { get; set; }

    public Edition Edition { get; set; }

    public string Remark { get; set; }
    public long? CreatedBy { get; set; }
    public long? UpdatedBy { get; set; }
    public bool IsDeleted { get; set; }
    public long? DeletedBy { get; set; }
    public DateTimeOffset? DeletedTime { get; set; }
}