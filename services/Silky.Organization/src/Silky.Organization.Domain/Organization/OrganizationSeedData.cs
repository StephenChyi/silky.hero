﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Silky.EntityFrameworkCore.Entities.Configures;
using Silky.Hero.Common.Enums;

namespace Silky.Organization.Domain;

public class OrganizationSeedData : IEntitySeedData<Organization>
{
    public IEnumerable<Organization> HasData(DbContext dbContext, Type dbContextLocator)
    {
        var initData = new List<Organization>();
        initData.Add(new Organization()
        {
            Id = 1,
            Name = "Silky.Hero社区",
            Code = "silky.hero",
            Status = Status.Valid,
            Sort = 1
        });
        initData.Add(new Organization()
        {
            Id = 2,
            Name = "Silky.Hero开发部",
            Code = "silky.hero.dev",
            Status = Status.Valid,
            ParentId = 1,
            Remark = "负责产品开发",
            Sort = 2,
        });
        initData.Add(new Organization()
        {
            Id = 3,
            Name = "Silky.Hero后端开发部",
            Code = "silky.hero.dev.services",
            Status = Status.Valid,
            ParentId = 2,
            Remark = "负责服务段接口开发",
            Sort = 3,
        });
        initData.Add(new Organization()
        {
            Id = 4,
            Name = "Silky.Hero前端开发部",
            Code = "silky.hero.dev.front",
            Status = Status.Valid,
            Remark = "负责前端UI、交互开发",
            ParentId = 2,
            Sort = 4,
        });
        initData.Add(new Organization()
        {
            Id = 5,
            Name = "Silky.Hero测试部",
            Code = "silky.hero.test",
            Status = Status.Valid,
            Remark = "负责产品测试",
            ParentId = 1,
            Sort = 4,
        });
        initData.Add(new Organization()
        {
            Id = 6,
            Name = "Silky.Hero产品部",
            Code = "silky.hero.product",
            Status = Status.Valid,
            Remark = "负责产品规划、设计",
            ParentId = 1,
            Sort = 6,
        });
        return initData;
    }
}