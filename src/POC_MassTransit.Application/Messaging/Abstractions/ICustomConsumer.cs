namespace POC_MassTransit.Application.Messaging.Abstractions;
public interface ICustomConsumer<TMessage> where TMessage : class
{
    Task Consume(TMessage message);
}
