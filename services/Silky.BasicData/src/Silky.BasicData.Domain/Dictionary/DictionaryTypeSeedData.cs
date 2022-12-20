using Microsoft.EntityFrameworkCore;
using Silky.EntityFrameworkCore.Entities.Configures;
using System;
using System.Collections.Generic;

namespace Silky.BasicData.Domain.Dictionary;

public class DictionaryTypeSeedData : IEntitySeedData<DictionaryType>
{
    public IEnumerable<DictionaryType> HasData(DbContext dbContext, Type dbContextLocator)
    {
        var initList = new List<DictionaryType>();

        initList.Add(new()
        {
            Id = 1,
            Code = "sex",
            Name = "性别",
            Sort = 1,
            TenantId = 1,
        });

        return initList;
    }
}