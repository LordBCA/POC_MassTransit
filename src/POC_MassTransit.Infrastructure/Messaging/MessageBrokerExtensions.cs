using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using POC_MassTransit.Application.Messaging.Abstractions;
using POC_MassTransit.Infrastructure.Messaging.Configurations;
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

            config.AddConsumers(assembly);

            MessageBrokerConfiguratorFactory.Create(config, messageBrokerOptions).Configure();            
        });

        services.AddSingleton<IMessageBrokerService, MessageBrokerService>();

        return services;
    }
}
