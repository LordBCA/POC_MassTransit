using MassTransit;

namespace POC_MassTransit.Infrastructure.Messaging.Configurations;

public class AzureServiceBusConfigurator(MessageBrokerOptions messageBrokerOptions) : IMessageBrokerConfigurator
{
    public void Configure(IBusRegistrationConfigurator config)
    {
        config.UsingAzureServiceBus((context, configurator) =>
                    {
                        configurator.Host(messageBrokerOptions.ConnectionString);
                        configurator.ConfigureEndpoints(context);
                    });
    }
}