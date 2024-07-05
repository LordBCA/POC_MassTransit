using MassTransit;

namespace POC_MassTransit.Infrastructure.Messaging.Configurations;

public class RabbitMQConfigurator(MessageBrokerOptions messageBrokerOptions) : IMessageBrokerConfigurator
{
    public void Configure(IBusRegistrationConfigurator config)
    {
        config.UsingRabbitMq((context, configurator) =>
                    {
                        configurator.Host(new Uri(messageBrokerOptions.Host!), host =>
                        {
                            host.Username(messageBrokerOptions.UserName);
                            host.Password(messageBrokerOptions.Password);
                        });
                        configurator.ConfigureEndpoints(context);
                    });
    }
}