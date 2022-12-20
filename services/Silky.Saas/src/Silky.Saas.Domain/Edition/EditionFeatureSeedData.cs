using Microsoft.EntityFrameworkCore;
using Silky.EntityFrameworkCore.Entities.Configures;
using System;
using System.Collections.Generic;

namespace Silky.Saas.Domain;

public class EditionFeatureSeedData : IEntitySeedData<EditionFeature>
{
    public IEnumerable<EditionFeature> HasData(DbContext dbContext, Type dbContextLocator)
    {
        var initData = new List<EditionFeature>();
        initData.Add(new()
        {
            Id = 1,
            EditionId = 1,
            FeatureId = 1,
            FeatureValue = 20
        });
        initData.Add(new()
        {
            Id = 2,
            EditionId = 1,
            FeatureId = 2,
            FeatureValue = 0
        });
        initData.Add(new()
        {
            Id = 3,
            EditionId = 1,
            FeatureId = 3,
            FeatureValue = 0
        });
        initData.Add(new()
        {
            Id = 4,
            EditionId = 1,
            FeatureId = 4,
            FeatureValue = 0
        });
        initData.Add(new()
        {
            Id = 5,
            EditionId = 1,
            FeatureId = 5,
            FeatureValue = 0
        });
        initData.Add(new()
        {
            Id = 6,
            EditionId = 2,
            FeatureId = 1,
            FeatureValue = 50
        });
        initData.Add(new()
        {
            Id = 7,
            EditionId = 2,
            FeatureId = 2,
            FeatureValue = 1
        });
        initData.Add(new()
        {
            Id = 8,
            EditionId = 2,
            FeatureId = 3,
            FeatureValue = 0
        });
        initData.Add(new()
        {
            Id = 9,
            EditionId = 2,
            FeatureId = 4,
            FeatureValue = 0
        });
        initData.Add(new()
        {
            Id = 10,
            EditionId = 1,
            FeatureId = 5,
            FeatureValue = 0
        });
        initData.Add(new()
        {
            Id = 11,
            EditionId = 3,
            FeatureId = 1,
            FeatureValue = 0
        });
        initData.Add(new()
        {
            Id = 12,
            EditionId = 3,
            FeatureId = 2,
            FeatureValue = 1
        });
        initData.Add(new()
        {
            Id = 13,
            EditionId = 3,
            FeatureId = 3,
            FeatureValue = 1
        });
        initData.Add(new()
        {
            Id = 14,
            EditionId = 3,
            FeatureId = 4,
            FeatureValue = 1
        });
        initData.Add(new()
        {
            Id = 15,
            EditionId = 3,
            FeatureId = 5,
            FeatureValue = 1
        });
        return initData;
    }
}