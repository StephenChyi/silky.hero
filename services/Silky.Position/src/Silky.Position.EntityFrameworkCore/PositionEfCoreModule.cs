﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Silky.Core.Modularity;
using Silky.Position.EntityFrameworkCore.DbContexts;
using System.Threading.Tasks;

namespace Silky.Position.EntityFrameworkCore;

public class PositionEfCoreModule : SilkyModule
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