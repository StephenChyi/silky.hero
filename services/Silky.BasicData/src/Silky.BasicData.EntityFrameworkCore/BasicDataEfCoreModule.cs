﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Silky.BasicData.EntityFrameworkCore.DbContexts;
using Silky.Core.Modularity;
using System.Threading.Tasks;

namespace Silky.BasicData.EntityFrameworkCore;

public class BasicDataEfCoreModule : SilkyModule
{
    public override async Task Initialize(ApplicationInitializationContext context)
    {
        if (context.HostEnvironment.IsDevelopment())
        {
            using var scope = context.ServiceProvider.CreateScope();
            await using var dbContext = scope.ServiceProvider.GetRequiredService<DefaultContext>();
            await dbContext.Database.MigrateAsync();
        }
    }
}