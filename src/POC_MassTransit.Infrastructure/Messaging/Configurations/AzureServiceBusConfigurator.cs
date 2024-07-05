using MassTransit;

namespace POC_MassTransit.Infrastructure.Messaging.Configurations;

public class AzureServiceBusConfigurator(IBusRegistrationConfigurator config, MessageBrokerOptions messageBrokerOptions) : IMessageBrokerConfigurator
{
    public void Configure()
    {
        config.UsingAzureServiceBus((context, configurator) =>
                    {
                        configurator.Host(messageBrokerOptions.ConnectionString);
                        configurator.ConfigureEndpoints(context);
                    });
    }
}