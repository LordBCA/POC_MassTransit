using MassTransit;
using POC_MassTransit.Application.Messaging.Abstractions;

namespace POC_MassTransit.Infrastructure.Messaging;

public class MessageBrokerService(IBusControl busControl) : IMessageBrokerService
{
    public async Task PublishAsync<T>(T message) where T : class
    {
        await busControl.Publish(message);
    }    
}
