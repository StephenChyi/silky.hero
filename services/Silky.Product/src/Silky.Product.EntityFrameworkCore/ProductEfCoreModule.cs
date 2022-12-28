﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Silky.Core.Modularity;
using Silky.EntityFrameworkCore.Contexts.Attributes;
using Silky.Product.Domain;
using Silky.Product.EntityFrameworkCore.DbContexts;

namespace Silky.Product.EntityFrameworkCore
{
    [AppDbContext(ProductDbProperties.ConnectionStringName, DbProvider.MySql)]
    public class ProductEfCoreModule : SilkyModule
    {
        public override async Task Initialize(ApplicationInitializationContext context)
        {
            if (context.HostEnvironment.IsDevelopment())
            {
                using var scope = context.ServiceProvider.CreateScope();
                await using var dbContext = scope.ServiceProvider.GetRequiredService<DefaultDbContext>();
                await dbContext.Database.MigrateAsync();
            }
        }
    }
}
