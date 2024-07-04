using MassTransit;
using POC_MassTransit.Application.Messaging.Abstractions;

namespace POC_MassTransit.Infrastructure.Messaging;

public class CustomConsumer<T, TMessage>(T customConsumer) : IConsumer<TMessage> where T : class, ICustomConsumer<TMessage>, new() where TMessage : class
{
    public Task Consume(ConsumeContext<TMessage> context)
    {
        return customConsumer.Consume(context.Message);
    }
}