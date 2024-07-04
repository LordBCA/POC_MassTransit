using MassTransit;
using POC_MassTransit.Application.Messaging.Abstractions;

namespace POC_MassTransit.Infrastructure.Messaging;

public class MessageBrokerProducerService(IBusControl busControl) : IMessageBrokerProducerService
{
    public async Task PublishAsync<T>(T message) where T : class
    {
        await busControl.Publish(message);
    }
}
