using MassTransit;

namespace POC_MassTransit.Infrastructure.Messaging.Configurations;

public interface IMessageBrokerConfigurator
{
    void Configure(IBusRegistrationConfigurator config);
}