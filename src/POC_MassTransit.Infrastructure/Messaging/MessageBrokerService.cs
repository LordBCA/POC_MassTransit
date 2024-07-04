using MassTransit;
using POC_MassTransit.Application.Messaging.Abstractions;

namespace POC_MassTransit.Infrastructure.Messaging;

public class MessageBrokerService(IBusControl busControl) : IMessageBrokerService
{
    public async Task PublishAsync<T>(T message) where T : class
    {
        await busControl.Publish(message);
    }

    //public void RegisterConsumer<T, TMessage>() where T : class, ICustomConsumer<TMessage>, new() where TMessage : class
    //{
    //    busControl.ConnectReceiveEndpoint(typeof(T).Name.ToLower() + "_queue", cfg =>
    //    {
    //        cfg.Consumer(() => ActivatorUtilities.CreateInstance<CustomConsumer<T, TMessage>>(serviceProvider));
    //    });
    //}
}
