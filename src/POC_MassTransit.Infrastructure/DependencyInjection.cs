﻿using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using POC_MassTransit.Application.Data;
using POC_MassTransit.Infrastructure.Data;
using POC_MassTransit.Infrastructure.Data.Interceptors;
using POC_MassTransit.Infrastructure.Messaging;
using System.Reflection;
using POC_MassTransit.Application.Messaging.Abstractions;

namespace POC_MassTransit.Infrastructure;
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices
        (this IServiceCollection services, IConfiguration configuration, Assembly applicationAssembly)
    {
        var connectionString = configuration.GetConnectionString("Database");

        // Add services to the container.
        services.AddScoped<ISaveChangesInterceptor, AuditableEntityInterceptor>();        

        services.AddDbContext<ApplicationDbContext>((sp, options) =>
        {
            options.AddInterceptors(sp.GetServices<ISaveChangesInterceptor>());
            options.UseSqlServer(connectionString);
        });

        services.AddScoped<IApplicationDbContext, ApplicationDbContext>();

        services.AddMessageBroker(configuration, applicationAssembly);

        services.AddSingleton<IMessageBrokerProducerService, MessageBrokerProducerService>();

        return services;
    }
}