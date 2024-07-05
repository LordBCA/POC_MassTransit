using MassTransit;

namespace POC_MassTransit.Infrastructure.Messaging.Configurations;

public class InMemoryConfigurator(IBusRegistrationConfigurator config) : IMessageBrokerConfigurator
{
    public void Configure()
    {
        config.UsingInMemory();
    }
}