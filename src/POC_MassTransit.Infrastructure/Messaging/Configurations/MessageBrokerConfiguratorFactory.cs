using MassTransit;

namespace POC_MassTransit.Infrastructure.Messaging.Configurations;

public static class MessageBrokerConfiguratorFactory
{
    public static IMessageBrokerConfigurator Create(IBusRegistrationConfigurator config, MessageBrokerOptions messageBrokerOptions)
    {
        return messageBrokerOptions.Service switch
        {
            "AzureServiceBus" => new AzureServiceBusConfigurator(config, messageBrokerOptions),
            "RabbitMQ" => new RabbitMQConfigurator(config, messageBrokerOptions),
            _ => new InMemoryConfigurator(config)
        };
    }
}