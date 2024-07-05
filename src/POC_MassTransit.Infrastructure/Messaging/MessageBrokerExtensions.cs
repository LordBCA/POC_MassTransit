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

        services.AddSingleton<MessageBrokerConfiguratorFactory>();

        services.AddMassTransit(config =>
        {
            config.SetKebabCaseEndpointNameFormatter();

            config.AddConsumers(assembly);            

            var provider = services.BuildServiceProvider();
            var factory = provider.GetRequiredService<MessageBrokerConfiguratorFactory>();
            var configurator = factory.Create();
            configurator.Configure(config);
               
        });        

        services.AddSingleton<IMessageBrokerService, MessageBrokerService>();

        return services;
    }
}
