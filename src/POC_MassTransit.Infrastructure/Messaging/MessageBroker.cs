using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using POC_MassTransit.Application.Messaging.Abstractions;
using System.Reflection;


namespace POC_MassTransit.Infrastructure.Messaging;
public static class Extentions
{
    public static IServiceCollection AddMessageBroker
        (this IServiceCollection services, IConfiguration configuration, Assembly? assembly = null)
    {
        services.AddMassTransit(config =>
        {
            config.SetKebabCaseEndpointNameFormatter();

            if (assembly != null)
                config.AddConsumers(assembly);

            switch (configuration["MessageBroker:Service"])
            {
                case "AzureServiceBus":
                    config.UsingAzureServiceBus((context, configurator) =>
                    {
                        configurator.Host("MessageBroker:ConnectionString");
                        configurator.ConfigureEndpoints(context);
                    });
                    break;
                case "RabbitMQ":
                    config.UsingRabbitMq((context, configurator) =>
                    {
                        configurator.Host(new Uri(configuration["MessageBroker:Host"]!), host =>
                        {
                            host.Username(configuration["MessageBroker:UserName"]);
                            host.Password(configuration["MessageBroker:Password"]);
                        });
                        configurator.ConfigureEndpoints(context);
                    });
                    break;
                default:
                    config.UsingInMemory();
                    break;
            }            
        });        

        services.AddSingleton<IMessageBrokerService, MessageBrokerService>();

        return services;
    }
}
