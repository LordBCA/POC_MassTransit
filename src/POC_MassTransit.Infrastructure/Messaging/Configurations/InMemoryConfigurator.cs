using MassTransit;

namespace POC_MassTransit.Infrastructure.Messaging.Configurations;

public class InMemoryConfigurator : IMessageBrokerConfigurator
{
    public void Configure(IBusRegistrationConfigurator config)
    {
        config.UsingInMemory();
    }
}