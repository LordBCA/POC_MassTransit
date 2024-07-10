using MassTransit;
using POC_MassTransit.Application.Notifications.EventHandlers;
using POC_MassTransit.Infrastructure.Data;

namespace POC_MassTransit.Infrastructure.Messaging.Configurations;

public class RabbitMQConfigurator(IBusRegistrationConfigurator config, MessageBrokerOptions messageBrokerOptions) : IMessageBrokerConfigurator
{
    public void Configure()
    {
        config.UsingRabbitMq((context, configurator) =>
                    {
                        configurator.Host(new Uri(messageBrokerOptions.Host!), host =>
                        {
                            host.Username(messageBrokerOptions.UserName);
                            host.Password(messageBrokerOptions.Password);
                        });
                        configurator.ConfigureEndpoints(context);
                        //configurator.ReceiveEndpoint(configurator =>
                        //{
                        //    configurator.UseMessageRetry(r => r.Intervals(10, 50, 100, 1000, 1000, 1000, 1000, 1000));
                        //    configurator.UseEntityFrameworkOutbox<ApplicationDbContext>(context);
                        //    configurator.ConfigureConsumer<CreateAssigmentEventHandler>(context);
                        //});
                    });
    }
}