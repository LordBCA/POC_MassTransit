using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using POC_MassTransit.Application.Messaging.Abstractions;
using System.Reflection;


namespace POC_MassTransit.Infrastructure.Messaging;
public static class MessageBrokerExtensions
{
    public static IServiceCollection AddMessageBroker
        (this IServiceCollection services, IConfiguration configuration, Assembly? assembly = null)
    {        
        var messageBrokerOptions = configuration.GetSection("MessageBroker").Get<MessageBrokerOptions>();

        services.AddMassTransit(config =>
        {
            config.SetKebabCaseEndpointNameFormatter();

            if (assembly != null)
                config.AddConsumers(assembly);            

            switch (messageBrokerOptions.Service)
            {
                case "AzureServiceBus":
                    config.UsingAzureServiceBus((context, configurator) =>
                    {
                        configurator.Host(messageBrokerOptions.ConnectionString);
                        configurator.ConfigureEndpoints(context);
                    });
                    break;
                case "RabbitMQ":
                    config.UsingRabbitMq((context, configurator) =>
                    {
                        configurator.Host(new Uri(messageBrokerOptions.Host!), host =>
                        {
                            host.Username(messageBrokerOptions.UserName);
                            host.Password(messageBrokerOptions.Password);
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
