﻿using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Silky.WorkFlow.EntityFrameworkCore.DbContexts;

namespace Silky.WorkFlowHost
{
    public class ConfigureService : IConfigureService
    {
        public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            //services.AddSilkySkyApm().AddObjectMapper();

            //services.AddMassTransit(x =>
            //{
            //    x.UsingRabbitMq((context, configurator) =>
            //    {
            //        configurator.Host(configuration["rabbitMq:host"],
            //            configuration["rabbitMq:port"].To<ushort>(),
            //            configuration["rabbitMq:virtualHost"],
            //            config =>
            //            {
            //                config.Username(configuration["rabbitMq:userName"]);
            //                config.Password(configuration["rabbitMq:password"]);
            //            });
            //        configurator.ReceiveEndpoint("auditlog-events-listener",
            //            e => { e.Consumer<AuditLogEventConsumer>(); });
            //    });
            //    services.AddMassTransitHostedService();
            //});

            services.AddDatabaseAccessor(options => { options.AddDbPool<DefaultContext>(); },"Silky.Log.Database.Migrations");
        }
    }
}
