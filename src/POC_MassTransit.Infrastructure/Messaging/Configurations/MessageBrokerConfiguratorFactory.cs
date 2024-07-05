using MassTransit;
using Microsoft.Extensions.Options;

namespace POC_MassTransit.Infrastructure.Messaging.Configurations;

public class MessageBrokerConfiguratorFactory(IOptions<MessageBrokerOptions> options)
{
    public IMessageBrokerConfigurator Create()
    {
        return options.Value.Service switch
        {
            "AzureServiceBus" => new AzureServiceBusConfigurator(options.Value),
            "RabbitMQ" => new RabbitMQConfigurator(options.Value),
            _ => new InMemoryConfigurator()
        };
    }
}